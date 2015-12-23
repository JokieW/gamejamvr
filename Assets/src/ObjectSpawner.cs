using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour 
{

    public List<GameObject> things;
    public static ObjectSpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void SpawnRandom()
    {
        GameObject go = (GameObject)GameObject.Instantiate(Instance.things[Random.Range(0, Instance.things.Count)], Instance.transform.position + RandomVector(2.0f), Quaternion.identity);
        go.AddComponent<StickyObject>();
        go.AddComponent<Trackable>();
        CollisionTracker ct = go.AddComponent<CollisionTracker>();
        ct.trackAmount = CollisionTracker.TrackAmount.Many;
        ct.trackType = CollisionTracker.TrackType.Trigger;
    }

    public static Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
