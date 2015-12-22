using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class StickyObject : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StickyObject>() != null)
        {
            FixedJoint fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            fj.enableCollision = false;
        }
    }

}
