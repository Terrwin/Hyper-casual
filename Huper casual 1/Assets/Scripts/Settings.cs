using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Text accelerationButtonColor;
    [SerializeField] private Text swipeButtonColor;
    
    private void Start()
    {
        Save.instance.LoadScore();
        if (Save.instance.controll == false)
        {
            textColorChange(Color.white, Color.grey);
        }
        else 
        {
            textColorChange(Color.grey, Color.white);
        }
        Save.instance.SaveScore();
    }

    public void accelerationOn()
    {
        Save.instance.LoadScore();
        Save.instance.controll = false;
        Save.instance.SaveScore();
        textColorChange(Color.white, Color.grey);
    }

    public void swipeOn()
    {
        Save.instance.LoadScore();
        Save.instance.controll = true;
        Save.instance.SaveScore();
        textColorChange(Color.grey, Color.white);
    }

    private void textColorChange(Color accelerationColor, Color swipeColor)
    {
        accelerationButtonColor.color = accelerationColor;
        swipeButtonColor.color = swipeColor;
    }
}   
