using UnityEngine;
using System.Collections;

public class ControllerBox : MonoBehaviour 
{

    public GameObject rightArm;
    public GameObject leftArm;

    public SteamVR_TrackedObject rightTracker;
    public CollisionTracker righthandTracker;

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

        if (rightIndex != -1)
        {
            SteamVR_Controller.Device device = SteamVR_Controller.Input(rightIndex);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                ObjectSpawner.SpawnRandom();
            }
            if (righthandTracker != null && righthandTracker.GetFirst() != null)
            {
                if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    righthandTracker.GetFirst().stickyObject.GrabIt(righthandTracker.transform);
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    if (!righthandTracker.GetFirst().stickyObject.TrySnap())
                    {
                        righthandTracker.GetFirst().stickyObject.ReleaseIt();
                    }
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
