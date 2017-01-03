using UnityEngine;
using System.Collections;

public class deco_1 : MonoBehaviour {

    private GameObject sphere1 = null;
    private GameObject sphere2 = null;
    private GameObject sphere3 = null;
    private GameObject sphere4 = null;

    private float speed = 0.5f;
    // Use this for initialization
    void Start () {

        sphere1 = transform.FindChild("Sphere").gameObject;
        sphere2 = transform.FindChild("Sphere (1)").gameObject;
        sphere3 = transform.FindChild("Sphere (2)").gameObject;
        sphere4 = transform.FindChild("Sphere (3)").gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (sphere1.transform.position.y >= (transform.position.y + 1.2))
            sphere1.transform.position -= new Vector3 (0, sphere1.transform.position.y - transform.position.y, 0);
        if (sphere2.transform.position.y >= (transform.position.y + 1.2))
            sphere2.transform.position -= new Vector3 (0, sphere2.transform.position.y - transform.position.y, 0);
        if (sphere3.transform.position.y >= (transform.position.y + 1.2))
            sphere3.transform.position -= new Vector3 (0, sphere3.transform.position.y - transform.position.y, 0);
        if (sphere4.transform.position.y >= (transform.position.y + 1.2))
            sphere4.transform.position -= new Vector3 (0, sphere4.transform.position.y - transform.position.y, 0);


        sphere1.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
        sphere2.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        sphere3.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        sphere4.transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        
    }
}
