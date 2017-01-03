﻿using UnityEngine;
using System.Collections;

public class human_move : MonoBehaviour {

    // body objects
    private GameObject body = null;

    private GameObject head = null;
    private GameObject left_arm = null;
    private GameObject right_arm = null;
    private GameObject left_leg = null;
    private GameObject right_leg = null;
    
    private float go = 60;
    private float until_go = 0;

    private Vector3 m_MoveDir = Vector3.zero;

    // control points
    private Vector3 cp1 = Vector3.zero;
    private Vector3 cp2 = Vector3.zero;
    private Vector3 cp3 = Vector3.zero;
    private Vector3 cp4 = Vector3.zero;
    private float t;

    // speed
    private float speed = 0.1f;


    // Use this for initialization
    void Start () {
        body = transform.FindChild("body").gameObject;
        head = body.transform.FindChild("head").gameObject;
        left_leg = body.transform.FindChild("Left_leg").gameObject;
        right_leg = body.transform.FindChild("Right_leg").gameObject;
        left_arm = body.transform.FindChild("Left_arm").gameObject;
        right_arm = body.transform.FindChild("Right_arm").gameObject;

        transform.position = new Vector3(0, 2.5f, -0.4f);
        m_MoveDir = transform.position;

        cp1 = new Vector3(0f, 1.6f, 0f);
        cp2 = new Vector3(-3f, 1.6f, -4f);
        cp3 = new Vector3(3f, 1.6f, -4f);
        cp4 = new Vector3(0f, 1.6f, -8f);

        t = 0;
    }

    // Update is called once per frame
    void Update () {

        until_go = until_go + Time.deltaTime;
        if (until_go >= 1)
        {
            until_go = -1;
            go = -go;
        }

        head.transform.Rotate(new Vector3(0, go, 0) * Time.deltaTime);
        left_arm.transform.Rotate(new Vector3(go, 0, 0) * Time.deltaTime);
        right_arm.transform.Rotate(new Vector3(-go, 0, 0) * Time.deltaTime);
        left_leg.transform.Rotate(new Vector3(-go, 0, 0) * Time.deltaTime);
        right_leg.transform.Rotate(new Vector3(go, 0, 0) * Time.deltaTime);

        t = t + Time.deltaTime * speed;

        if (t >= 1)
            t = 0;
        float argu1 = Mathf.Pow(1 - t, 3);
        float argu2 = 3 * Mathf.Pow(1 - t, 2) * t;
        float argu3 = 3 * (1 - t) * Mathf.Pow(t, 2);
        float argu4 = Mathf.Pow(t, 3);

        m_MoveDir = argu1 * cp1 + argu2 * cp2 + argu3 * cp3 + argu4 * cp4;

        transform.position = m_MoveDir;
    }
}
