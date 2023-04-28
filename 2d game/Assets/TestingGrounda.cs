using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestingGrounda : MonoBehaviour
{
    public void OnBackButtonPressed()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex + 3;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }
}
