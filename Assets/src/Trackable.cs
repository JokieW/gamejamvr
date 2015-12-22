using UnityEngine;
using System.Collections;

public class Trackable : MonoBehaviour 
{
    CompCache<StickyObject> _sticky;
    public StickyObject stickyObject
    {
        get
        {
            return _sticky.get;
        }
    }

    void Awake()
    {
        _sticky = new CompCache<StickyObject>(gameObject);
    }
}
