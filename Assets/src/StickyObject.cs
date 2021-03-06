﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class StickyObject : MonoBehaviour {

    public bool Sticked = false;
    Rigidbody body;
    CollisionTracker tracker;
    public static int StickiedCount;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        tracker = GetComponent<CollisionTracker>();
        tracker.typeFilter = typeof(StickyObject);
    }

    void OnJointBreak(float breakForce)
    {
        Sticked = false;
        gameObject.layer = 0;
    }

    public void GrabIt(Transform to)
    {
        if (!Sticked)
        {
            transform.SetParent(to);
            gameObject.layer = 10;
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void ReleaseIt(Vector3 velocity)
    {
        transform.SetParent(null);
        
        gameObject.layer = 0;
        body.constraints = RigidbodyConstraints.None;
        body.velocity = velocity * 2.0f;
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
                Debug.Log(tr.gameObject);
                fj.connectedBody = tr.gameObject.GetComponent<Rigidbody>();
                fj.enableCollision = false;
                fj.breakForce = 100000;
                fj.breakTorque = 100000;
            }
            body.constraints = RigidbodyConstraints.None;
            Sticked = true;
            StickiedCount++;
            return true;
        }
        return false;
    }
}
