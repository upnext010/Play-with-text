using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // Required for scene management

public class SceneLoader : MonoBehaviour
{
    // Method to load a scene by name
    public void LoadScene1()
    {
        SceneManager.LoadScene("Create Question");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("Load Question");
    }
}