using UnityEngine;
using System.Collections;

public class Entrance_music : MonoBehaviour {

    public GameObject player;
    private AudioSource music;
    
    void Awake ()
    {
        music = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            music.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
