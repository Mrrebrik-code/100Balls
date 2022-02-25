using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] spawnBucketObject;
    private Transform spawnTransform;

    private void Start()
    {
        spawnTransform = transform;
        StartCoroutine(enumerator());
    }
    private void SpawnObject()
    {
        var min = 0;
        var max = spawnPoint.Length;
        var randomNumber = Random.Range(min, max);

        if (spawnTransform.position.x == -spawnPoint[randomNumber].position.x && spawnTransform.position.y == spawnPoint[randomNumber].position.y)
        {
            var previousTransform = spawnTransform;
            spawnTransform = previousTransform;
        }
        else
        {
            spawnTransform = spawnPoint[randomNumber];
        }
        var randomBucketNumber = Random.Range(0, spawnBucketObject.Length);
        var bucketObject = Instantiate(spawnBucketObject[randomBucketNumber], spawnTransform);
        bucketObject.AddComponent<BucketBehaviour>();
    }
    IEnumerator enumerator()
    {
        while(true)
        {
            SpawnObject();
            yield return new WaitForSeconds(3.0f);
        }
    }
}