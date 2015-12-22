using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class HandCollider : MonoBehaviour 
{
    public StickyObject CurrentlyTracking;

    void Awake()
    {
        SphereCollider sc = GetComponent<SphereCollider>();
        sc.radius = 0.1f;
        sc.isTrigger = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        StickyObject so = collider.gameObject.GetComponent<StickyObject>();
        if (so != null)
        {
            CurrentlyTracking = so;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        StickyObject so = collider.gameObject.GetComponent<StickyObject>();
        if (so != null && CurrentlyTracking == so)
        {
            CurrentlyTracking = null;
        }
    }
}
