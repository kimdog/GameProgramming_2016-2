using UnityEngine;
using System.Collections;

public class beforeExit : MonoBehaviour {

    public GameObject player;

    private AudioSource exit_sound;


    void Awake()
    {
        exit_sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            exit_sound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
