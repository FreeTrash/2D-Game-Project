using UnityEngine;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
    public void LoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 2);
    }
}
