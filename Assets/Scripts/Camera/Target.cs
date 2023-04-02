using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Camera camera;


    public float smoothSpeed = 0.125f;
    public Transform target;


    // Update is called once per frame
    void Update()
    {


        // Get a vector pointing in the direction we need. TIP: for
        // vectors, a - b = c, where c is a vector that points in the
        // direction of the first vector(which is a) in relation to b.
        Vector3 desiredForward = target.position - camera.transform.position;

        // Make it unit length!
        desiredForward.Normalize();

        // Build a look rotation from the desired forward.
        Quaternion desiredRotation = Quaternion.LookRotation(desiredForward);

        // Smoothly blend from the cameras current rotation, to the
        // desired rotation...
        float smoothing = 5f;
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, desiredRotation, smoothing * Time.deltaTime);


    }
}