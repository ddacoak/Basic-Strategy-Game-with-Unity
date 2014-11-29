using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
    // Parameters
    public float spawnInterval = 3.0f;
    float spawnIntervalElapsed = 0.0f;

    void Update()
    {
        // Build it every few seconds
        spawnIntervalElapsed += Time.deltaTime;
        if (spawnIntervalElapsed >= spawnInterval)
        {
            // Use UnitSpawner
            GetComponent<UnitsSpawner>().spawn();

            // Reset interval
            spawnIntervalElapsed = 0.0f;
        }
    }
}