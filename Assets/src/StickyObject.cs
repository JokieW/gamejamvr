using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class StickyObject : MonoBehaviour {

    public bool Sticked = false;

    void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.GetComponent<StickyObject>() != null)
        {
            FixedJoint fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            fj.enableCollision = false;
        }*/
    }

}
