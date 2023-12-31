using UnityEditor;
using UnityEngine;
using System.Collections;

// Create a 180 degrees wire arc with a ScaleValueHandle attached to the disc
// that lets you modify the "radius" value in the WireArcExample
[CustomEditor(typeof(Follow))]
public class EnemiesSpawnEditor : Editor
{
    void OnSceneGUI()
    {
        Handles.color = Color.red;
        Follow myObj = (Follow)target;
        float radius = 5.0f;
        Handles.DrawWireArc(myObj.transform.position, Vector3.forward, myObj.transform.right, 180, radius);
        radius = (float)Handles.ScaleValueHandle(radius, 
            myObj.transform.position + Vector3.up * radius, 
            myObj.transform.rotation, 2.0f, 
            Handles.CylinderHandleCap, 1);
    }
}