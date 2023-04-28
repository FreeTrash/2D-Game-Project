using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class SpawnPrefabOnKeyPress : MonoBehaviour

{
    public float buttonPressDistance = 5f;

    [SerializeField] private GameObject prefab;

    [SerializeField] private Vector2 spawnPosition;

    [SerializeField] private bool random;

    public void OnSpawnAPrefab()

    {

        if (random)

        {

            float x = Random.Range(-8, 8);

            float y = Random.Range(-4, 4);

            Instantiate(prefab, new Vector2(x, y), Quaternion.identity);

        }

        else

        {

            Instantiate(prefab, spawnPosition, Quaternion.identity);

        }

    }
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) <= buttonPressDistance)
        {
           if (Input.GetKeyDown(KeyCode.F))
            {
                OnSpawnAPrefab();
            }
           
        }
    }
}