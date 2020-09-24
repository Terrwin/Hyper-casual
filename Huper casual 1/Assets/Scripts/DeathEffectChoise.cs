using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEffectChoise : MonoBehaviour
{
    [SerializeField]private GameObject deathScreen;

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("DeathScreen");
    }

    public void Resurrect()
    {
        Save.instance.LoadScore();
        if (Save.instance.points >= 50)
        {
            Time.timeScale = 1;
            Save.instance.points -= 50;
            Save.instance.SaveScore();
            deathScreen.SetActive(false);
            PlatformRotation.instance.ResurrectStart();
        }
    }
}
