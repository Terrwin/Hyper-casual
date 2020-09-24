using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform sphere;

    void FixedUpdate()
    {
        transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y + 15, sphere.transform.position.z + 30);
    }
}
