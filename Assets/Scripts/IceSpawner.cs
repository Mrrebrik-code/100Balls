using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private GameObject spawnObject;
    private enum SpawnFlipper
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
        var randomNumber = Random.Range(-1, 1);
        var flipper = (SpawnFlipper)randomNumber;

        if (flipper == SpawnFlipper.Left) Instantiate(spawnObject, leftSpawnPoint);
        else Instantiate(spawnObject, rightSpawnPoint);
    }
    IEnumerator Enumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            SpawnObject();
        }
    }
}
