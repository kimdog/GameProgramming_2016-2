using UnityEngine;
using System.Collections;

public class my_down_drawcall : MonoBehaviour {

    public GameObject FPScontroller;

    private Transform[] objects_transform;

    // Use this for initialization
    void Start () {
        // get children objects
        objects_transform = GetComponentsInChildren<Transform>();
        
        // except self
        for (int i = 1; i < objects_transform.Length; i++)
        {
            if (objects_transform[i].gameObject.tag == "Shootable")
            {
                objects_transform[i].gameObject.SetActive(true);
                continue;
            }
            objects_transform[i].gameObject.SetActive(false);
        }
	}

    // Update is called once per frame
    void Update() {

        // except self
        for (int i = 1; i < objects_transform.Length; i++) {

            if (objects_transform[i].gameObject.tag == "Shootable")
            {
                continue;
            }

            if (Vector3.Distance(objects_transform[i].position, FPScontroller.transform.position) < 60f)
                objects_transform[i].gameObject.SetActive(true);
            else
            {
                // if plane, always draw
                if (objects_transform[i].gameObject.tag == "plane")
                {
                    continue;
                }
                objects_transform[i].gameObject.SetActive(false);
            }
        }
	}
}
