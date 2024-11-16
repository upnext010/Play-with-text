using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; // Make sure to include the TextMeshPro namespace

public class TextCollector3 : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text optionA;
    public TMP_Text optionB;
    public TMP_Text optionC;
    public TMP_Text optionD;
    private int currentIndex = 0;
    public Button changeTextButton;

    public List<GameObject> textObjects; // List of GameObjects with TextMeshPro

    public List<string> textList = new List<string>(); // List to store text values

       void Start()
        {
            // Step: Get Text from TextMeshPro components and store them in the list
            /*foreach (GameObject textObject in textObjects)
            {
                TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>(); //

                if (textMeshPro != null)
                {
                    textList.Add(textMeshPro.text); // Store the text value
                }
            }*/

            // For demonstration, let's change the text in the list
            //textList[] = "Updated Text!";
            textList.Add("Unity");
            textList.Add("Unity1");
            textList.Add("Unity2");
        if (textList.Count > 0)
            {
                question.text = textList[currentIndex];
            }

            // Add listener for button click
            changeTextButton.onClick.AddListener(SetText);


    }

       /* void Update()
        {
            // Step: Assign text back to the TextMeshPro components
            if (textObjects.Count >  && textList.Count > )
            {
                for (int i = ; i < textObjects.Count && i < textList.Count; i++)
                {
                    TextMeshProUGUI textMeshPro = textObjects[i].GetComponent<TextMeshProUGUI>(); // Get the TextMeshPro component

                    if (textMeshPro != null)
                    {
                        textMeshPro.text = textList[i]; // Assign the updated text
                    }
                }
            }
        }*/


        public void SetText()
        {
        /*question.text = "I am qestion?";
        optionA.text = "I am option A";
        optionB.text = "I am option B";
        optionC.text = "I am option C";
        optionD.text = "I am option D";
        textList.Add("Unity");*/

        currentIndex = (currentIndex + 1) % textList.Count;

        // Update the TMP_Text with the new string
        question.text = textList[currentIndex];

        //question.text = textList;  // Add each string with a new line
        foreach (string str in textList)
        {
            Debug.Log(str);
        }

        /*foreach (string str in textList)
        {
            question.text = str;  // Add each string with a new line
        }*/
    }
}













    
     


 

