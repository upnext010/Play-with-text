using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObjects/TextData", order = 2)]
public class TextData : ScriptableObject
{
    public string text;  // The text data to save/load
}
