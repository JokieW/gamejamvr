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
        righthandTracker = rightArm.AddComponent<CollisionTracker>();
        righthandTracker.typeFilter = typeof(StickyObject);
    }

    void Update()
    {
        if (SteamVR_Controller.Input((int)rightTracker.index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || Input.GetKeyDown(KeyCode.K))
        {
            ObjectSpawner.SpawnRandom();
        }
        if (righthandTracker != null && righthandTracker.GetFirst() != null)
        {
            if (SteamVR_Controller.Input((int)rightTracker.index).GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                righthandTracker.GetFirst().stickyObject.GrabIt(righthandTracker.transform);
            }
            if (SteamVR_Controller.Input((int)rightTracker.index).GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                righthandTracker.GetFirst().stickyObject.ReleaseIt();
            }
        }
    }

    public Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
