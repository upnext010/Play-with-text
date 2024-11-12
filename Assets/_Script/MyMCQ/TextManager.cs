using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour

{
    public TextData textData;  // Reference to the ScriptableObject

    // Save text to the ScriptableObject
    public void SaveText(string newText)
    {
        if (textData != null)
        {
            textData.text = newText;
            Debug.Log("Text saved: " + newText);
        }
        else
        {
            Debug.LogError("TextData is not assigned!");
        }
    }

    // Load text from the ScriptableObject
    public string LoadText()
    {
        if (textData != null)
        {
            Debug.Log("Text loaded: " + textData.text);
            return textData.text;
        }
        else
        {
            Debug.LogError("TextData is not assigned!");
            return string.Empty;
        }
    }
}
