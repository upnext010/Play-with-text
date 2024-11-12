using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for InputField or Text components
using Random = UnityEngine.Random;
using TMPro; // Add TMP namespace for TextMeshPro integration
using Unity.VisualScripting;

public class TestSpawner : MonoBehaviour
{
    public SaveSystem saveSystem;
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;

    public CopyPasteSystem copyPasteSystem; // Reference to CopyPasteSystem

    public List<GameObject> createdPrefabs = new List<GameObject>();
    public List<GameObject> createdPrefabs2 = new List<GameObject>();
    public List<GameObject> createdPrefabs3 = new List<GameObject>();

    public void Clear()
    {
        foreach (var item in createdPrefabs)
        {
            Destroy(item);
        }
        createdPrefabs.Clear();

        foreach (var item in createdPrefabs2)
        {
            Destroy(item);
        }
        createdPrefabs2.Clear();

        foreach (var item in createdPrefabs3)
        {
            Destroy(item);
        }
        createdPrefabs3.Clear();
    }

    public void SpawnPrefab()
    {
        createdPrefabs.Add(Instantiate(prefab, transform.position, Quaternion.identity));
    }

    public void SpawnPrefab2()
    {
        createdPrefabs2.Add(Instantiate(prefab2, transform.position, Quaternion.identity));
    }

    public void SpawnPrefab3()
    {
        GameObject newPrefab3 = Instantiate(prefab3, transform.position, Quaternion.identity);
        createdPrefabs3.Add(newPrefab3);

        //createdPrefabs3.Add(Instantiate(prefab3, transform.position, Quaternion.identity));
        

        // Find the TMP_InputField component in prefab3 and paste copied text
        /*TMP_InputField inputField = newPrefab3.GetComponentInChildren<TMP_InputField>();
        if (inputField != null)
        {
            copyPasteSystem.PasteFromClipboard();  // Use CopyPasteSystem to paste
            inputField.text = copyPasteSystem.output.text;  // Set the pasted text to the inputField   
        }*/
        TextMeshProUGUI inputField = newPrefab3.GetComponentInChildren<TextMeshProUGUI>();
        if (inputField != null)
        {
            copyPasteSystem.PasteFromClipboard();  // Use CopyPasteSystem to paste
            inputField.text = copyPasteSystem.output.text;  // Set the pasted text to the inputField   TextMeshProUGUI
        }
    }



    public void SaveGame(int slotNumber)
    {
        SaveData data = new SaveData();

        // Save createdPrefabs and createdPrefabs2
        foreach (var item in createdPrefabs)
        {
            data.Add(item, null); // No text for prefab1
        }
        foreach (var item in createdPrefabs2)
        {
            data.Add(item, null); // No text for prefab2
        }
        foreach (var item in createdPrefabs3)
        {
            // Get the text from prefab3's InputField or Text component
            //string text = item.GetComponentInChildren<InputField>()?.text ?? ""; // Adjust depending on your setup
            string text = item.GetComponentInChildren<TextMeshProUGUI>()?.text ?? "";
            data.Add(item, text);
        }

        var dataToSave = JsonUtility.ToJson(data);
        saveSystem.SaveData(dataToSave, slotNumber);
    }

    public void LoadGame(int slotNumber)
    {
        Clear();
        string dataToLoad = saveSystem.LoadData(slotNumber);
        if (!string.IsNullOrEmpty(dataToLoad))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(dataToLoad);
            foreach (var objData in data.objectData)
            {
                GameObject newObj = null;
                


                if (objData.type.StartsWith("Cube"))
                    newObj = Instantiate(prefab, objData.position.GetValue(), Quaternion.identity);
                if (objData.type.StartsWith("Sphere"))
                    newObj = Instantiate(prefab2, objData.position.GetValue(), Quaternion.identity);
                if (objData.type.StartsWith("Canvas 6"))
                    newObj = Instantiate(prefab3, objData.position.GetValue(), Quaternion.identity);
                    TextMeshProUGUI inputField = newObj.GetComponentInChildren<TextMeshProUGUI>();
                    inputField.text = objData.text;
                    newObj.name = objData.type;
                    createdPrefabs3.Add(newObj);
                    



                /*{
            newObj = Instantiate(prefab3, objData.position.GetValue(), Quaternion.identity);
            // Set the text on the prefab3's InputField or Text component
            //InputField inputField = newObj.GetComponentInChildren<InputField>();
            TextMeshProUGUI inputField = newObj.GetComponentInChildren<TextMeshProUGUI>();

            if (inputField != null)
            {
                inputField.text = objData.text;
            }   
        }*/
                /*if (newObj != null)
                {
                    newObj.name = objData.type;
                    createdPrefabs.Add(newObj);
                }*/
            }
        }
    }

    [Serializable]
    public class SaveData
    {
        public List<ObjectSerialization> objectData;

        public SaveData()
        {
            objectData = new List<ObjectSerialization>();
        }
        public void Add(GameObject obj, string text)
        {
            objectData.Add(new ObjectSerialization(obj.name, obj.transform.position, text));
        }
    }

    [Serializable]
    public class ObjectSerialization
    {
        public Vector3Serialization position;
        public string type;
        public string text; // Add text field for prefab3

        public ObjectSerialization(string t, Vector3 pos, string textData)
        {
            this.type = t;
            this.position = new Vector3Serialization(pos);
            this.text = textData; // Store text
        }
    }

    [Serializable]
    public class Vector3Serialization
    {
        public float x, y, z;

        public Vector3Serialization(Vector3 position)
        {
            this.x = position.x;
            this.y = position.y;
            this.z = position.z;
        }

        public Vector3 GetValue()
        {
            return new Vector3(x, y, z);
        }
    }
}