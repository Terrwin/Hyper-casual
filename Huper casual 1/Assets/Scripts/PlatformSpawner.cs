﻿using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;
    public GameObject[] platformsPrefabs;
    public GameObject[] platforms;
    public int score = 0;
    public float speed = 0.05f;
    [SerializeField]private Text text;
    [SerializeField]private Transform spawn;
    
    private void Start()
    {
        instance = this;
        platforms = GameObject.FindGameObjectsWithTag("Platform");
    }
    private void FixedUpdate() 
    {   
        for (int i = 0; i < 10; i++)
        {
            if (platforms[i].transform.position.z >= 15f || platforms[i] == null)
            {
                Destroing(platforms[i]);
                score += 1;
                text.text = score.ToString();
                platforms[i] = Instantiate(platformsPrefabs[Random.Range(0, 3)], spawn.position, spawn.rotation) as GameObject;
            }
            platforms[i].transform.position = new Vector3(platforms[i].transform.position.x, platforms[i].transform.position.y, platforms[i].transform.position.z + speed);
        }
    }

    public void Destroing(GameObject platform)
    {
        Destroy(platform);
    }

    public void PreviousScore(int previousScore)
    {
        score = previousScore;
    }
}
