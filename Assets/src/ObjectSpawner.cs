using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{

    public GameObject thing;
    public SteamVR_TrackedObject rightHand;
    public SteamVR_TrackedObject leftHand;


	void Update () 
    {
        if (SteamVR_Controller.Input((int)rightHand.index).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject.Instantiate(thing, transform.position + RandomVector(2.0f), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject.Instantiate(thing, transform.position + RandomVector(2.0f), Quaternion.identity);
        }
	}

    public Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
