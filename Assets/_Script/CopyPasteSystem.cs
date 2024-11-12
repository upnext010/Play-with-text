using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopyPasteSystem : MonoBehaviour
{
    //public InputField inputField;
    public TMP_InputField inputField;
    //public InputField inputField2;
    public TextMeshProUGUI output;


    public void CopyToClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = inputField.text;
        textEditor.SelectAll();
        textEditor.Copy();  //Copy string from textEditor.text to Clipboard
    }
 
    public void PasteFromClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();  //Copy string from Clipboard to textEditor.text
        output.text = textEditor.text;
    }

}
