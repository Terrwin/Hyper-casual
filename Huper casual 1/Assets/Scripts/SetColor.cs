using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    [SerializeField]private int number;
    public void SetColors()
    {
        ShopMenu.instance.CheckEnable(number);
    }
}
