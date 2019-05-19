using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyModel;

    private float timer = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(timer >= 5.0f)
        {
            Vector3 randPos = new Vector3(Random.Range(1.0f, 100.0f), 0.0f, Random.Range(1.0f, 100.0f));
            Instantiate(enemyModel, randPos, Quaternion.identity);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
}
