using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class HandCollider : MonoBehaviour 
{
    public StickyObject CurrentlyTracking;

    void Awake()
    {
        GetComponent<SphereCollider>().radius = 0.2;
    }

    void OnCollisionEnter(Collision collision)
    {
        StickyObject so = collision.gameObject.GetComponent<StickyObject>();
        if (so != null)
        {
            CurrentlyTracking = so;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        StickyObject so = collision.gameObject.GetComponent<StickyObject>();
        if (so != null && CurrentlyTracking == so)
        {
            CurrentlyTracking = null;
        }
    }
}
