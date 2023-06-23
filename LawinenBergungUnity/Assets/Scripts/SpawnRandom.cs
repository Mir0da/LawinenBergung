using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject rightSnowPile;
    [SerializeField] private GameObject[] falseSnowPiles;

    private float MinX = 0;
    private float MaxX = 120;
    //Y ist fix damit die Haufen nicht ind er Luft herumschweben 
    private float MinY = 10;
    private float MaxY = 10;
    private float MinZ = 0;
    private float MaxZ = 130;

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

    private void SpawnObject1()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        float z = Random.Range(MinZ, MaxZ);

        dummy.transform.position = new Vector3(x, y, z);
    }

    private Vector3 randomVect()
    {
        float x = Random.Range(MinX, MaxX);
        //Y ist fix damit die Haufen nicht ind er Luft herumschweben 
        //float y = Random.Range(MinY, MaxY);
        float y = 8.5f; //Testhöhe
        float z = Random.Range(MinZ, MaxZ);

        return new Vector3(x, y, z);;
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
        dummy.transform.position = randomVector;
        rightSnowPile.transform.position = randomVector;

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
