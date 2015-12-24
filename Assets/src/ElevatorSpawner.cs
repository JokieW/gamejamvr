using UnityEngine;
using System.Collections;

public class ElevatorSpawner : MonoBehaviour {

    bool spawned = false;
    public GameObject elevator;


    void Update () 
    {
        if (!spawned && StickyObject.StickiedCount >= 5)
        {
            elevator.SetActive(true);
            spawned = true;
        }
	}
}
