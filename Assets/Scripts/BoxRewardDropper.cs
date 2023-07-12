using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRewardDropper : MonoBehaviour
{
    public float spawnHeight = 1f;
    public GameObject coinPrefab;
    public GameObject healthPrefab;
    public GameObject fastPrefab;
    public GameObject jumpPrefab;
    public GameObject magnetPrefab;

    public void DropCoin()
    {
        float randomValue = Random.value; // 0 ile 1 aras�nda rasgele bir de�er al
        if (randomValue < 0.5f) // %50 olas�l�k
        {
            InstantiatePrefab(coinPrefab);
        }
        else if (randomValue < 0.6f) // %10 olas�l�k
        {
            InstantiatePrefab(healthPrefab);
        }
        else if (randomValue < 0.7f) // %10 olas�l�k
        {
            InstantiatePrefab(fastPrefab);
        }else if (randomValue < 0.8f) // %10 olas�l�k
        {
            InstantiatePrefab(jumpPrefab);
        }
        else // %20 olas�l�k
        {
            InstantiatePrefab(magnetPrefab);
        }
    }

    private void InstantiatePrefab(GameObject prefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Vector3 spawnPosition = hit.point + Vector3.up * spawnHeight;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
