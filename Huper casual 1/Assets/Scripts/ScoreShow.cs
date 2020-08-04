using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text score;
    public Text maxScore;

    private void Start() 
    {
        score.text = PlatformSpawner.instance.score.ToString();
        maxScore.text = Save.instance.score.ToString();
    }
}
