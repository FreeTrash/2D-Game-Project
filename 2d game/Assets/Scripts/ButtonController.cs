using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door; // The door that will be opened when the button is pressed
    public float doorOpenSpeed; // The speed at which the door will open
    public float buttonPressDistance; // The distance at which the button will be considered "pressed"

    public GameObject Promt;

    private bool isPressed; // Flag to keep track of whether the button is being pressed or not

    public AudioClip buttonPress; // The audio clip that will be played
    private AudioSource audioSource; // The audio source component

    private void Start()
    {
        Promt.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = buttonPress;
    }
    void Update()
    {
        // Check if the player is within the buttonPressDistance of the button
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= buttonPressDistance)
        {

            Promt.SetActive(true);
            // If the player presses the interact button (e.g. space bar), set isPressed flag to true
            if (Input.GetKeyDown(KeyCode.F))
            {
                isPressed = true;
                audioSource.PlayOneShot(buttonPress);
            }
        }
        else
        {
            // If the player moves away from the button, set isPressed flag to false
            isPressed = false;
            Promt.SetActive(false);
        }

        // If the button is being pressed, open the door
        if (isPressed)
        {
            // Calculate the new position for the door based on doorOpenSpeed
            Vector3 newPosition = door.transform.position;
            newPosition.y += doorOpenSpeed * Time.deltaTime;

            // Move the door to the new position
            door.transform.position = newPosition;
            
        }
    }
}

