using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class StickyObject : MonoBehaviour {

    public bool Sticked = false;
    Rigidbody body;
    CollisionTracker tracker;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        tracker = GetComponent<CollisionTracker>();
        tracker.typeFilter = typeof(StickyObject);
    }

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        Sticked = false;
        gameObject.layer = 0;
    }

    public void GrabIt(Transform to)
    {
        if (!Sticked)
        {
            transform.SetParent(to);
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void ReleaseIt()
    {
        transform.SetParent(null);
        body.constraints = RigidbodyConstraints.None;
    }

    public bool TrySnap()
    {
        List<Trackable> tracks = tracker.GetAll();
        if (tracks.Count > 0)
        {
            transform.SetParent(null);
            gameObject.layer = 8;
            foreach (Trackable tr in tracks)
            {
                FixedJoint fj = gameObject.AddComponent<FixedJoint>();
                fj.connectedBody = tr.gameObject.GetComponent<Rigidbody>();
                fj.enableCollision = false;
                fj.breakForce = 10000;
                fj.breakTorque = 1000;
            }
            body.constraints = RigidbodyConstraints.None;
            Sticked = true;
            return true;
        }
        return false;
    }
}
