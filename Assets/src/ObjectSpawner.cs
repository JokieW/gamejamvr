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
        GameObject.Instantiate(Instance.things[Random.Range(0, Instance.things.Count)], Instance.transform.position + RandomVector(2.0f), Quaternion.identity);
    }

    public static Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
