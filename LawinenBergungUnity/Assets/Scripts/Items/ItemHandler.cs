using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class ItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shovel;
    

    //[SerializeField]private PostProcessProfile sunGlassProfile;
    //[SerializeField]private PostProcessProfile startProfile;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawnShovel()
    {
        SpawnInFront(shovel);
    }
    private void SpawnInFront(GameObject thing)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 5;
            
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
        
        Debug.Log("Spawned Shovel!");
        thing.transform.position = spawnPos;
    }
    
    public void PlaceMarker()
    { 
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;
            
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
            
        Debug.Log("Spawned Marker!");
       // Instantiate(markerPrefab, spawnPos, playerRotation);
    }
    
    public void PutOnSunGlasses()
    { 
        Debug.Log("Put On Glasses!");
        //deactivate LightSources
        
        //change Postprocessing Filters

    }
}

