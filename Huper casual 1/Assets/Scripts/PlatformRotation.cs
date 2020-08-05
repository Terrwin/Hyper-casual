using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformRotation : MonoBehaviour
{
    private Transform platform = null;
    private Transform previousPlatform;
    private float X = 0;
    
    void FixedUpdate()
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

    private void OnCollisionEnter(Collision other) 
    {
        if (platform != other.gameObject.transform)
        {
            previousPlatform = platform;
            platform = other.gameObject.transform;
            X = 0;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Respawn")
        {
            Save.instance.LoadScore();
            if (PlatformSpawner.instance.score > Save.instance.score)
            {
                Save.instance.score = PlatformSpawner.instance.score;
                Save.instance.points += PlatformSpawner.instance.score;
                Save.instance.SaveScore();
            }
            else 
            {
                Save.instance.points += PlatformSpawner.instance.score;
                Save.instance.SaveScore();
            }
            SceneManager.LoadScene("DeathScreen");
        }
        if (other.gameObject.tag == "SideOfPlatform")
        {
            PlatformSpawner.instance.Destroing(previousPlatform.gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
