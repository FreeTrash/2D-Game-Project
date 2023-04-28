using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    void Start()
    {
        // Attach the CloseGame method to the button's "onClick" event
        Button closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(closeGame);
    }

    void closeGame()
    {
        // Close the game
        Application.Quit();
    }
}
