using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform sphere;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y + 15, sphere.transform.position.z + 30);
    }
}
