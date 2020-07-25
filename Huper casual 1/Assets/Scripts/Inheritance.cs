using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance : MonoBehaviour
{
    private float a = 1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public virtual void Jump()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + a, transform.position.z);
        
    }
}
