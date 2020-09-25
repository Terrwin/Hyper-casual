using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]private List<GameObject> colorImages;
    [SerializeField]private List<GameObject> checkImages;
    [SerializeField]private List<GameObject> notBuyedImages;
    [SerializeField]private GameObject DontHavePointsText;
    private int flag = 0;
    private List<int> price = new List<int>(){0, 100, 1000, 1000, 1000, 1000, 1000, 10000};  
    public static ShopMenu instance;

    private void Start()
    {
        instance = this;
        Save.instance.LoadScore();
        CheckEnable(Save.instance.currentColor);
        for (int i = 0; i < 8; i++)
        {
            colorImages[i].GetComponent<Image>().color = Menu.instance.ballColorsSO[i].color;
        }
    }

    public void MenuExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CheckEnable(int number)
    {
        DontHavePointsText.SetActive(false);
        for (int j = 0; j < Save.instance.colors.Count; j++)
        {
            notBuyedImages[Save.instance.colors[j]].SetActive(false);
            if (Save.instance.colors[j] == number)
            {
                Save.instance.currentColor = number;
                checkImages[number].SetActive(true);
                for (int k = 0; k < 8; k++)
                {
                    if (k != number)
                    {
                        checkImages[k].SetActive(false);
                    }
                }
            }
            else 
            {
                flag++;
            }
        }
        if (flag == Save.instance.colors.Count)
        {
            if (Save.instance.colors.Count == 0)
            {
                Save.instance.colors = new List<int>(){0};
            }
            if (Save.instance.colors.Count != 0 && Save.instance.points >= price[number])
            {
                Save.instance.colors.Add(number);
                Save.instance.points -= price[number];
                Save.instance.currentColor = number;
                checkImages[number].SetActive(true);
                notBuyedImages[number].SetActive(false);
                for (int k = 0; k < 8; k++)
                {
                    if (k != number)
                    {
                        checkImages[k].SetActive(false);
                    }
                }
            }
            else if (Save.instance.points < price[number])
            {
                DontHavePointsText.SetActive(true);
            }
        }
        flag = 0;
        checkImages[Save.instance.currentColor].SetActive(true);
        Save.instance.SaveScore();
    }
}
