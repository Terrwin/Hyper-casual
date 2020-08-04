using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformRotation : MonoBehaviour
{
    [SerializeField]private Transform platform;
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
            SceneManager.LoadScene("DeathScreen");
            Save.instance.LoadGame();
            if (PlatformSpawner.instance.score > Save.instance.score)
            {
                Save.instance.score = PlatformSpawner.instance.score;
                Save.instance.SaveGame();
            }
        }
        if (other.gameObject.tag == "SideOfPlatform")
        {
            PlatformSpawner.instance.Destroing(previousPlatform.gameObject);
        }
    }
}
