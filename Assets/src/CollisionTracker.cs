using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class CollisionTracker : MonoBehaviour 
{
    public TrackAmount trackAmount = TrackAmount.One;
    public TrackType trackType = TrackType.Trigger;
    public float radius;

    public Type typeFilter;

    List<Trackable> _tracked = new List<Trackable>();

    Rigidbody body;
    SphereCollider colliderTrigger;
    SphereCollider colliderCollision;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        SphereCollider[] scs = GetComponents<SphereCollider>();
        colliderTrigger = gameObject.AddComponent<SphereCollider>();
        colliderTrigger.isTrigger = true;
        colliderTrigger.radius = radius;

        colliderCollision = gameObject.AddComponent<SphereCollider>();
        colliderCollision.isTrigger = false;
        colliderCollision.radius = radius;
    }

    public Trackable GetFirst()
    {
        if (_tracked.Count == 0)
        {
            return null;
        }
        return _tracked[0];
    }

    public List<Trackable> GetAll()
    {
        return _tracked;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (trackType == TrackType.Collision || trackType == TrackType.Both)
        {
            Trackable track = collision.gameObject.GetComponent<Trackable>();
            if (track != null)
            {
                if (typeFilter == null || track.GetComponent(typeFilter) != null)
                {
                    if (trackAmount == TrackAmount.Many)
                    {
                        if (!_tracked.Contains(track))
                        {
                            _tracked.Add(track);
                        }
                    }
                    else if (_tracked.Count == 0)
                    {
                        _tracked.Add(track);
                    }
                }
            }
        }
    }

    /*void OnCollisionStay(Collision collision)
    {
        if (trackType == TrackType.Collision || trackType == TrackType.Both)
        {

        }
    }*/

    void OnCollisionExit(Collision collision)
    {
        if (trackType == TrackType.Collision || trackType == TrackType.Both)
        {
            Trackable track = collision.gameObject.GetComponent<Trackable>();
            if (_tracked.Contains(track))
            {
                _tracked.Remove(track);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (trackType == TrackType.Trigger || trackType == TrackType.Both)
        {
            Trackable track = collider.gameObject.GetComponent<Trackable>();
            if (track != null)
            {
                if (typeFilter == null || track.GetComponent(typeFilter) != null)
                {
                    if (trackAmount == TrackAmount.Many)
                    {
                        if (!_tracked.Contains(track))
                        {
                            _tracked.Add(track);
                        }
                    }
                    else if (_tracked.Count == 0)
                    {
                        _tracked.Add(track);
                    }
                }
            }
        }
    }

    /*void OnTriggerStay(Collider collider)
    {
        if (trackType == TrackType.Trigger || trackType == TrackType.Both)
        {
            
        }
    }*/

    void OnTriggerExit(Collider collider)
    {
        if (trackType == TrackType.Trigger || trackType == TrackType.Both)
        {
            Trackable track = collider.gameObject.GetComponent<Trackable>();
            if (_tracked.Contains(track))
            {
                _tracked.Remove(track);
            }
        }
    }

    public enum TrackAmount
    {
        One,
        Many
    }

    public enum TrackType
    {
        Trigger,
        Collision,
        Both
    }
}
