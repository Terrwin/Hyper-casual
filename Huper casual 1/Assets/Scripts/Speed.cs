using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    private int score = 0;
    void FixedUpdate()
    {
        if (PlatformSpawner.instance.score % 20 == 0 && PlatformSpawner.instance.score != score)
        {
            score = PlatformSpawner.instance.score;
            PlatformSpawner.instance.speed += 0.01f;
        }
    }
}
