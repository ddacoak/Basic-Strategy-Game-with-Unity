﻿using UnityEngine;
using System.Collections;

public class UnitsSpawner : MonoBehaviour
{
    public GameObject unit;
    public float spawnRange = 1.5f;

    public void spawn()
    {
        Vector3 pos = transform.position;
        float x = pos.x + Random.Range(-1.0f, 1.0f) * spawnRange;
        float y = pos.y;
        float z = pos.z + Random.Range(-1.0f, 1.0f) * spawnRange;
        float angle = Random.Range(0.0f, 360.0f);
        Instantiate(unit, new Vector3(x, y, z), Quaternion.Euler(0.0f, angle, 0.0f));
    }
}