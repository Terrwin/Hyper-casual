using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    [SerializeField]private Text score;
    [SerializeField]private Text maxScore;

    private void Start() 
    {
        score.text = PlatformSpawner.instance.score.ToString();
        maxScore.text = Save.instance.score.ToString();
    }
}
