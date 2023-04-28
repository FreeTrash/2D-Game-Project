using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // The distance the object will float up and down
    public float floatSpeed = 1f; // The speed at which the object will float up and down

    private Vector3 startPos; // The starting position of the object

    void Start()
    {
        startPos = transform.position; // Store the starting position of the object
    }

    void Update()
    {
        // Calculate the new position of the object based on its starting position, the float amplitude, and the float speed
        Vector3 newPosition = startPos;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Set the position of the object to the new position
        transform.position = newPosition;
    }
}