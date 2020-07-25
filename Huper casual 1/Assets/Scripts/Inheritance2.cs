using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance2 : Inheritance
{
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }*/
    private float rotY = 0;
    public override void Jump()
    {
        base.Jump();
        rotY += 90f; 
        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
        
    }
}
