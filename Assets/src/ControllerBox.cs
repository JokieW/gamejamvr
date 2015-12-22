using UnityEngine;
using System.Collections;

public class ControllerBox : MonoBehaviour 
{

    public GameObject rightArm;
    public GameObject leftArm;

    CompCache<SteamVR_TrackedObject> _rightTracker;
    HandCollider rightHandCollider;

    void Awake()
    {
        _rightTracker = new CompCache<SteamVR_TrackedObject>(gameObject);
        rightHandCollider = rightArm.AddComponent<HandCollider>();
    }

    void Update()
    {
        if (SteamVR_Controller.Input((int)_rightTracker.get.index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || Input.GetKeyDown(KeyCode.K))
        {
            ObjectSpawner.SpawnRandom();
        }
        if (rightHandCollider != null && rightHandCollider.CurrentlyTracking != null)
        {
            if (SteamVR_Controller.Input((int)_rightTracker.get.index).GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                rightHandCollider.CurrentlyTracking.transform.SetParent(rightHandCollider.transform);
            }
            if (SteamVR_Controller.Input((int)_rightTracker.get.index).GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                rightHandCollider.CurrentlyTracking.transform.SetParent(null);
            }
        }
    }

    public Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
