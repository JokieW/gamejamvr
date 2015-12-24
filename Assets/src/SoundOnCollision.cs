using UnityEngine;
using System.Collections;

public class SoundOnCollision : MonoBehaviour {

    public AudioSource clip;
    bool played = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!played)
        {
            clip.Play();
            played = true;
        }
    }
}
