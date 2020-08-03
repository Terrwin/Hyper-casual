using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu");
    }
}
