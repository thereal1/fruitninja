using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

    public float minDelay = .1f;
    public float maxDelay = 1f;
    public GameObject[] objects;
    public Transform[] spawnPoints;


    public void StartSpawning()
    {
        StartCoroutine("SpawnFruits");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnFruits");
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject spawnedFruit = Instantiate(objects[Random.Range(0, objects.Length)], 
                spawnPoint.position, 
                spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }

}
