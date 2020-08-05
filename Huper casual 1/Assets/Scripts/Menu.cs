using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]private Text pointsText;
    public static Menu instance;
    
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

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
        Save.instance.LoadScore();
        pointsText.text = Save.instance.points.ToString();
    }
}