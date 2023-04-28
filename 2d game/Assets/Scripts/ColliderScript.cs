using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public GameObject GlowingChest; // The sprite object to be activated
    public GameObject RegularChest;
    public float buttonPressDistance;

    void Start()
    {
        RegularChest.SetActive(true);
        GlowingChest.SetActive(false);
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= buttonPressDistance)
        {
            GlowingChest.SetActive(true);
            RegularChest.SetActive(false);
        }
        else
        {
            RegularChest.SetActive(true);
            GlowingChest.SetActive(false);
        }

    }
}
   