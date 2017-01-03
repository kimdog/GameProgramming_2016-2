using UnityEngine;
using System.Collections;

public class SplineWalker : MonoBehaviour {

    public BezierSpline spline;

    public float duration;

    public float progress;

    public bool lookForward;

    // mode
    public SplineWalkerMode mode;
    private bool goingForward = true;
	
	// Update is called once per frame
	private void Update () {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                // once
                if (mode == SplineWalkerMode.Once)
                {
                    progress = 1f;
                }
                // loop
                else if (mode == SplineWalkerMode.Loop)
                {
                    progress -= 1f;
                }
                // pingpong
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            // going backward
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);
     //   transform.localPosition = position;
        transform.position = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
	}
}
