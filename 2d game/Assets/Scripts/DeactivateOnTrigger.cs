using UnityEngine;

public class DeactivateOnTrigger : MonoBehaviour
{
    public GameObject objectToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
