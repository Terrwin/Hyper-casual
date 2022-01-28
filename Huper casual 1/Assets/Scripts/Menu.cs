using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    public List<BallColorSO> ballColorsSO;
    [SerializeField]private Text pointsText;

    private void Start()
    {
        instance = this;
        PointsRefresh();
    }

    private void Update() 
    {
        PointsRefresh();
    } 

    public void PointsRefresh()
    {
        if (pointsText != null)
        {
            Save.instance.LoadScore();
            pointsText.text = Save.instance.points.ToString();
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void MenuExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}