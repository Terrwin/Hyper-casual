using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text text;

    private void Start() 
    {
        text.text = PlatformSpawner.instance.score.ToString();
    }
}
