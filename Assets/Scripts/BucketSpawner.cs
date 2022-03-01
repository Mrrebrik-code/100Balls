using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketSpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] spawnPoint;
    [SerializeField] private GameObject spawnObject;
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
        var bucketObject = Instantiate(spawnObject, transform);
        var bucket = bucketObject.AddComponent<BucketBehaviour>();
        SetBucketColor(bucket);
        bucketObject.transform.position = spawnPosition;
    }
    private void SetBucketColor(BucketBehaviour bucket)
    {
        var score = ScoreView.Instance.Score;

        if (score > 50 && score < 200)
        {
            bucket.Property.bucketColor = BucketProperty.BucketColor.Red;
        }
        else if (score > 200 && score < 400)
        {
            bucket.Property.bucketColor = BucketProperty.BucketColor.Blue;
        }
        else if (ScoreView.Instance.Score > 400)
        {
            bucket.Property.bucketColor = BucketProperty.BucketColor.Green;
        }
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