using UnityEngine;
using System.Collections;

public class arrow_scrip : MonoBehaviour {

    private float speed;
    private float timer;
    private Vector2 max_size;
    private RectTransform rt;

    private float size_err;

    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        speed = 1f;
        size_err = 0.01f;
        max_size = new Vector2(3f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (rt.sizeDelta.y > max_size.y - size_err)
        {
            rt.sizeDelta = new Vector2(3f, 2f);
            timer = 0;
            timer = Mathf.Clamp(timer - Time.deltaTime * speed, 0.0f, 1.0f);
        }
        else
        {
            timer = Mathf.Clamp(timer + Time.deltaTime * speed, 0.0f, 1.0f);
        }

        rt.sizeDelta = Vector2.Lerp(rt.sizeDelta, max_size, speed * timer);
        
    }
}
