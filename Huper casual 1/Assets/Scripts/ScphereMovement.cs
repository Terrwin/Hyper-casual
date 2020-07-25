using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScphereMovement : MonoBehaviour
{
    public int stars = 0;
    public Transform camera;
    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Vector3.left * 100f * Time.deltaTime);
        camera.transform.position = new Vector3(transform.position.x + 10, transform.position.y + 10, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 500f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
             rb.AddForce(Vector3.down * 500f);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag == "Star")
        {
            stars += 1;
            Destroy(other.gameObject);
        }
    }
}
