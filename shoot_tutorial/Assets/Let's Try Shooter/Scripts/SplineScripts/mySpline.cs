using UnityEngine;
using System.Collections;


public class mySpline : MonoBehaviour {

    public Vector3 p0, p1;
    
	// Use this for initialization
	void Start () {
        p0 += transform.position;
        p1 += transform.position;    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
