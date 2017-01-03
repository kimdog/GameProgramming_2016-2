using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(mySpline))]
public class LineInspector : Editor {

	private void OnSceneGUI ()
    {
        mySpline line = target as mySpline;
        Transform handleTransform = line.transform;
        // check pivot vs global
        Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ?
            handleTransform.rotation : Quaternion.identity;
        Vector3 p0 = handleTransform.TransformPoint(line.p0);
        Vector3 p1 = handleTransform.TransformPoint(line.p1);

        Handles.color = Color.white;
        Handles.DrawLine(line.p0, line.p1);
        //Handles.DoPositionHandle(p0, handleRotation);
        //Handles.DoPositionHandle(p1, handleRotation);

        EditorGUI.BeginChangeCheck();
        p0 = Handles.DoPositionHandle(p0, handleRotation);
        if(EditorGUI.EndChangeCheck())
        {
            // use undo operation
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p0 = handleTransform.InverseTransformPoint(p0);
        }

        EditorGUI.BeginChangeCheck();
        p1 = Handles.DoPositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            // use undo operation
            Undo.RecordObject(line, "Move Point");
            EditorUtility.SetDirty(line);
            line.p1 = handleTransform.InverseTransformPoint(p1);
        }

    }
}
