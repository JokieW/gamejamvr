﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CollisionTracker : MonoBehaviour 
{
    public TrackAmount trackAmount = TrackAmount.One;
    public TrackType trackType = TrackType.Trigger;
    public float radius;

    public Type typeFilter;
    public string tagFilter;

    List<Trackable> _tracked = new List<Trackable>();

    void Awake()
    {

        if (radius != 0)
        {
            SphereCollider sc = gameObject.AddComponent<SphereCollider>();
            sc.isTrigger = trackType == TrackType.Trigger || trackType == TrackType.Both;
            sc.radius = radius;
        }
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
                bool good = false;
                if (typeFilter != null)
                {
                    good = track.GetComponent(typeFilter) != null;
                }
                else if (!String.IsNullOrEmpty(tagFilter))
                {
                    good = track.tag == tagFilter;
                }
                else
                {
                    good = true;
                }
                if (good)
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
                bool good = false;
                if (typeFilter != null)
                {
                    good = track.GetComponent(typeFilter) != null;
                }
                else if (!String.IsNullOrEmpty(tagFilter))
                {
                    good = track.tag == tagFilter;
                }
                else
                {
                    good = true;
                }
                if (good)
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
