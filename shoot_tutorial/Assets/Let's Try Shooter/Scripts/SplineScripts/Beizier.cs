﻿using UnityEngine;
using System.Collections;

public static class Beizier {

    public static Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        /*
        // Lerp means B(t) = (1-t)P0 + tP1
        // return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);

        // B(t) = (1-t)^2 * p0 + 2 * (1-t) * t * p1 + t^2 * p2
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * p0 +
            2f * oneMinusT * t * p1 +
            t * t * p2;
        */


        // Bezier Cubic curve
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;

    }


    // B'(t) = 2(1-t)(p1 - p0) + 2t(p2 - p1)
    public static Vector3 GetFirstDerivative (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        /*
        return
            2f * (1f - t) * (p1 - p0) +
            2f * t * (p2 - p1);
        */


        // Bezier Cubic curve
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
    

}
