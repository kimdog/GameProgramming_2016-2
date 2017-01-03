using UnityEngine;
using System.Collections;

public class canvas_rotate : MonoBehaviour {

    public GameObject FPScontorller;

    private Vector3 userPosition;

	
	// Update is called once per frame
	void Update () {
        // look forward
        userPosition = FPScontorller.transform.position;
        
        transform.LookAt(userPosition);
	}
}
