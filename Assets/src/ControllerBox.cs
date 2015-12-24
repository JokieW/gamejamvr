using UnityEngine;
using System.Collections;

public class ControllerBox : MonoBehaviour 
{

    public GameObject rightArm;
    public GameObject leftArm;

    public SteamVR_TrackedObject rightTracker;
    public CollisionTracker righthandTracker;

    Trackable heldObject;

    void Awake()
    {
        righthandTracker = rightArm.GetComponent<CollisionTracker>();
        righthandTracker.typeFilter = typeof(StickyObject);
    }

    void Update()
    {
        int rightIndex = (int)rightTracker.index;

        if (Input.GetKeyDown(KeyCode.K))
        {
            ObjectSpawner.SpawnRandom();
        }

        if (rightIndex != -1 && Limiter.unblocked)
        {
            SteamVR_Controller.Device device = SteamVR_Controller.Input(rightIndex);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                ObjectSpawner.SpawnRandom();
            }
            if (righthandTracker != null && (heldObject != null || righthandTracker.GetFirst() != null))
            {
                if (heldObject == null && device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    heldObject = righthandTracker.GetFirst();
                    heldObject.stickyObject.GrabIt(righthandTracker.transform);
                }
                if (heldObject != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    if (!heldObject.stickyObject.TrySnap())
                    {
                        heldObject.stickyObject.ReleaseIt(device.velocity);
                    }
                    heldObject = null;
                }
               /* if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    righthandTracker.GetFirst().stickyObject.TrySnap();
                }*/
            }
        }
    }

    public Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
