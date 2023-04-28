using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public Image HealthBar;
    public int maxHealth = 100;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            Destroy(gameObject);
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(nextSceneIndex);

        }
    }

}
