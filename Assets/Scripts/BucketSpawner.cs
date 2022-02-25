using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] spawnPoint;
    [SerializeField] private GameObject[] spawnBucketObject;
    private Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = Vector3.zero;
        StartCoroutine(SpawnCoroutine());
    }
    private void SpawnObject()
    {
        var min = 0;
        var max = spawnPoint.Length;
        var randomNumber = Random.Range(min, max);

        if (spawnPosition.x == -spawnPoint[randomNumber].x && spawnPosition.y == spawnPoint[randomNumber].y)
        {
            var previousTransform = spawnPosition;
            spawnPosition = previousTransform;
        }
        else
        {
            spawnPosition = spawnPoint[randomNumber];
        }
        var randomBucketNumber = Random.Range(0, spawnBucketObject.Length);
        var bucketObject = Instantiate(spawnBucketObject[randomBucketNumber], transform);
        bucketObject.AddComponent<BucketBehaviour>();
        bucketObject.transform.position = spawnPosition;
    }
    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            SpawnObject();
            yield return new WaitForSeconds(3.0f);
        }
    }
}