using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Color", menuName = "Color")]
public class BallColorSO : ScriptableObject
{
    public Color color;
    public Image image;
    public Material material;
}
