﻿using UnityEngine;
using System.Collections;

public class Limiter : MonoBehaviour 
{
    public static bool unblocked = false;

	void Update () 
    {
        if (!unblocked && Time.time > 110.0f)
        {
            unblocked = true;
            Debug.Log("Unblocked");
        }
	}
}
