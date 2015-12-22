using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class StickyObject : MonoBehaviour {

    public bool Sticked = false;
    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.GetComponent<StickyObject>() != null)
        {
            FixedJoint fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            fj.enableCollision = false;
        }*/
    }

    public void GrabIt(Transform to)
    {
        transform.SetParent(to);
        body.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void ReleaseIt()
    {
        transform.SetParent(null);
        body.constraints = RigidbodyConstraints.None;
    }
}
