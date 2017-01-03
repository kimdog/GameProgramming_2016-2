using UnityEngine;
using System.Collections;

public class Exit_music : MonoBehaviour {

    public GameObject player;
    public GameObject city;

    private AudioSource music;
    private AudioSource city_music;
    
    void Awake ()
    {
        music = GetComponentInParent<AudioSource>();
        city_music = city.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            city_music.Play();
            music.Stop();
            
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
