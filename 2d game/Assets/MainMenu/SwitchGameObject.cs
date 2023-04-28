using UnityEngine;
using UnityEngine.UI;

public class SwitchGameObject : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    void Start()
    {
        // Attach the SwitchGameObjects method to the button's "onClick" event
        Button switchButton = GetComponent<Button>();
        switchButton.onClick.AddListener(SwitchGameObjects);
    }

    public void SwitchGameObjects()
    {
        // Deactivate the first game object
        objectToDeactivate.SetActive(false);

        // Activate the second game object
        objectToActivate.SetActive(true);
    }
}
