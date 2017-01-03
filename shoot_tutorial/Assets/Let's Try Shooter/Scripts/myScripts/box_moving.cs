using UnityEngine;
using System.Collections;


public class box_moving : MonoBehaviour {

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
      
        transform.position = new Vector3( 0, 0.5f, -0.4f);
        m_MoveDir = transform.position;

        cp1 = new Vector3(-5f, 0.5f, -8f);
        cp2 = new Vector3(-5f, 5f, -4f);
        cp3 = new Vector3(5f, 5f, -4f);
        cp4 = new Vector3(5f, 0.5f, -8f);

        t = 0;

    }

    // Update is called once per frame
    void Update () {
        //    m_MoveDir.y = m_MoveDir.y + Time.deltaTime;
        t = t + Time.deltaTime * speed;

        if (t >= 1)
            t = 0;
        float argu1 = Mathf.Pow(1 - t, 3);
        float argu2 = 3 * Mathf.Pow(1 - t, 2) * t;
        float argu3 = 3 * (1 - t) * Mathf.Pow(t, 2);
        float argu4 = Mathf.Pow(t, 3);

        m_MoveDir = argu1 * cp1 + argu2 * cp2 + argu3 * cp3 + argu4 * cp4;

        transform.position = m_MoveDir;
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
