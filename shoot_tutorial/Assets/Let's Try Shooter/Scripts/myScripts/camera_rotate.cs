using UnityEngine;
using System.Collections;

public class camera_rotate : MonoBehaviour {

    private Vector3 m_Input;
    private float TurnSpeed;

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;
    private float upDownRange = 90;

    // Use this for initialization
    void Start () {
        TurnSpeed = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        horizontalRotation += horizontal * TurnSpeed;
        
        verticalRotation -= vertical * TurnSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);

    }
}
