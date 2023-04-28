using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueMessages; // The array of messages that the NPC will say
    public float displayTime = 2f; // The time (in seconds) each message will be displayed
    public KeyCode interactKey = KeyCode.F; // The key that the player will use to interact with the NPC

    private bool isDisplayingMessage; // Flag to keep track of whether a message is currently being displayed or not
    private int currentMessageIndex; // The index of the current message being displayed

    void Start()
    {
        isDisplayingMessage = false;
        currentMessageIndex = 0;
    }

    void Update()
    {
        // Check if the player is within a certain distance of the NPC
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= 2f)
        {
            // If the player presses the interact key, display the next message (if there are any left)
            if (Input.GetKeyDown(interactKey))
            {
                if (currentMessageIndex < dialogueMessages.Length)
                {
                    StartCoroutine(DisplayMessage(dialogueMessages[currentMessageIndex]));
                    currentMessageIndex++;
                }
            }
        }
    }

    // Coroutine to display a message for a certain amount of time and then hide it
    IEnumerator DisplayMessage(string message)
    {
        isDisplayingMessage = true;
        Debug.Log(message); // Display the message in the console (you can replace this with code to display the message on screen)

        yield return new WaitForSeconds(displayTime);

        isDisplayingMessage = false;
        Debug.Log(""); // Clear the console (you can replace this with code to clear the message from the screen)
    }
}
