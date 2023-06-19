using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private GameObject spawnObj;

    private float MinX = 0;
    private float MaxX = 10;
    private float MinY = 0;
    private float MaxY = 10;
    private float MinZ = 0;
    private float MaxZ = 10;

    private List<Vector3> spawnPoints;

    private void Awake()
    {
        spawnPoints = new List<Vector3>();
        
        spawnPoints.Add(new Vector3(5,5,5));
        spawnPoints.Add(new Vector3(10,-2,3));
        spawnPoints.Add(new Vector3(1,7,7));
    }

    public void Start()
    {
        SpawnObject2();
    }

    private void SpawnObject1()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        float z = Random.Range(MinZ, MaxZ);

        spawnObj.transform.position = new Vector3(x, y, z);
    }
    
    private void SpawnObject2()
    {
        Vector3 randomVector = GetRandomVector3();
        spawnObj.transform.position = randomVector;
    }

    private Vector3 GetRandomVector3()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("Die Liste von Vector3-Objekten ist leer.");
            return Vector3.zero;
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);
        return spawnPoints[randomIndex];
    }
    
}
