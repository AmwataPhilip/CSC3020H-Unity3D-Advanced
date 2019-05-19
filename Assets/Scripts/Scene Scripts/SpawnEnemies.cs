using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyModel;

    private int count = 0;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (count <= 20)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 15.0f));
            Vector3 randPos = new Vector3(Random.Range(1.0f, 15.0f), 0.5f, Random.Range(1.0f, 15.0f));
            Instantiate(enemyModel, randPos, Quaternion.identity);
            count++;
        }
    }
}
