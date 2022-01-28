using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformRotation : MonoBehaviour
{
    public static PlatformRotation instance;
    public Material[] ballColor;
    [SerializeField]private GameObject deathScreen;
    [SerializeField]private Text timerText;
    private Transform platform = null;
    private Transform previousPlatform;
    private float X = 0;
    private int previousScore = 0;
    private bool controll;
    
    private void Start() 
    {
        instance = this;
        Save.instance.LoadScore();        
        gameObject.GetComponent<Renderer>().material = Menu.instance.ballColorsSO[Save.instance.currentColor].material;
        controll = Save.instance.controll;
    }

    private void FixedUpdate()
    {
        if (controll == false)
        {
            X += Input.acceleration.x / 2f;
            platform.rotation = Quaternion.Euler(0f, 0f, X);
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    X += Input.GetAxis("Mouse X") / 4f;
                    platform.rotation = Quaternion.Euler(0f, 0f, X);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (platform != other.gameObject.transform)
        {
            platform = other.gameObject.transform;
            X = 0;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Respawn" || other.gameObject.tag == "DeathField")
        {
            Save.instance.LoadScore();
            if (PlatformSpawner.instance.score > Save.instance.score)
            {
                Save.instance.score = PlatformSpawner.instance.score - previousScore;
                Save.instance.points += PlatformSpawner.instance.score - previousScore;
                previousScore = PlatformSpawner.instance.score;
                Save.instance.SaveScore();
            }
            else 
            {
                Save.instance.points += PlatformSpawner.instance.score - previousScore;
                previousScore = PlatformSpawner.instance.score;
                Save.instance.SaveScore();
            }
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }

    public void ResurrectStart()
    {
        StartCoroutine(Resurrect());
    }

    IEnumerator Resurrect()
    {
        gameObject.transform.position = new Vector3(0f, 1f, 5f);
        X = 0;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < 10; i++)
        {
            walls[i].GetComponent<BoxCollider>().enabled = false;
        }
        timerText.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            timerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        timerText.gameObject.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            if (walls[i] != null)
            {
                walls[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

}
