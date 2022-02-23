using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private GameObject spawnObject;
    private enum SpawnSide
    {
        Left,
        Right
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(Enumerator());
        }
    }
    private void SpawnObject()
    {
        var randomNumber = Random.Range(0, 2);
        var spawnSide = (SpawnSide)randomNumber;

        if (spawnSide == SpawnSide.Left) Instantiate(spawnObject, leftSpawnPoint);
        else Instantiate(spawnObject, rightSpawnPoint);
    }
    IEnumerator Enumerator()
    {
        for (int i = 0; i < 16; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
}
