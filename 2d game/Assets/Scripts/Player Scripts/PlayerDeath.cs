using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerDeath : MonoBehaviour
{

    public Image HealthBar;
  

    public int Health = 100;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        HealthBar.fillAmount = Health / 100f;

        if (Health <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Shake.Instance.ShakeCamera(10f, .2f);


        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
    // Start is called before the first frame update
}
    // Update is called once per frame
    
