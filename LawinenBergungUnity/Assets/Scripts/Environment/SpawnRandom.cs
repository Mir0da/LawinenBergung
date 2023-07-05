using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private GameObject rightSnowPile;
    [SerializeField] private GameObject[] falseSnowPiles;

    private float MinX = 10;
    private float MaxX = 70;
    private float MinZ = -70;
    private float MaxZ = 70;

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
        SpawnDummy();
        SpawnPiles();
        
    }

    // private void SpawnObject1()
    // {
    //     float x = Random.Range(MinX, MaxX);
    //     float y = Random.Range(MinY, MaxY);
    //     float z = Random.Range(MinZ, MaxZ);
    //
    //     dummy.transform.position = new Vector3(x, y, z);
    // }

    private Vector3 randomVect()
    {
        float x = Random.Range(MinX, MaxX);
        //Y ist 0 damit die Haufen nicht ind er Luft herumschweben 
        float z = Random.Range(MinZ, MaxZ);

        return new Vector3(x, 0, z);;
    }
    
    private void SpawnPiles()
    {
        foreach (GameObject pile in falseSnowPiles)
        {
            Vector3 randomVector = randomVect();
            pile.transform.position = randomVector;
        }
        
    }
    
    private void SpawnDummy()
    {
        Vector3 randomVector = randomVect();
        rightSnowPile.transform.position = randomVector;

        // Vector3 temp = randomVector;
        // temp.x += 0.9f;
        // temp.y -= 0.12f;
        // randomVector = temp;
        // dummy.transform.position = randomVector;

    }

    // private Vector3 GetRandomVector3()
    // {
    //     if (spawnPoints.Count == 0)
    //     {
    //         Debug.LogWarning("Die Liste von Vector3-Objekten ist leer.");
    //         return Vector3.zero;
    //     }
    //
    //     int randomIndex = Random.Range(0, spawnPoints.Count);
    //     return spawnPoints[randomIndex];
    // }
    
}
