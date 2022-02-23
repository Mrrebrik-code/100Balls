using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] spawnGlassObject;
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
        var randomGlassNumber = Random.Range(0, spawnGlassObject.Length);
        var glassObject = Instantiate(spawnGlassObject[randomGlassNumber], spawnTransform);
        glassObject.AddComponent<GlassBehaviour>();
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