using UnityEngine;
using System.Collections;

public class ControllerBox : MonoBehaviour 
{

    public GameObject rightArm;
    public GameObject leftArm;

    public SteamVR_TrackedObject rightTracker;
    HandCollider rightHandCollider;

    void Awake()
    {
        rightHandCollider = rightArm.AddComponent<HandCollider>();
    }

    void Update()
    {
        if (SteamVR_Controller.Input((int)rightTracker.index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || Input.GetKeyDown(KeyCode.K))
        {
            ObjectSpawner.SpawnRandom();
        }
        if (rightHandCollider != null && rightHandCollider.CurrentlyTracking != null)
        {
            if (SteamVR_Controller.Input((int)rightTracker.index).GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                rightHandCollider.CurrentlyTracking.GrabIt(rightHandCollider.transform);
            }
            if (SteamVR_Controller.Input((int)rightTracker.index).GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                rightHandCollider.CurrentlyTracking.ReleaseIt();
            }
        }
    }

    public Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
