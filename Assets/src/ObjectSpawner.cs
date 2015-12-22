using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour 
{

    public GameObject thing;
    public static ObjectSpawner Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void SpawnRandom()
    {
        GameObject.Instantiate(Instance.thing, Instance.transform.position + RandomVector(2.0f), Quaternion.identity);
    }

    public static Vector3 RandomVector(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
