using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class ItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shovel;
    [SerializeField] private GameObject locator;
    

    //[SerializeField]private PostProcessProfile sunGlassProfile;
    //[SerializeField]private PostProcessProfile startProfile;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawnShovel()
    {
        SpawnInFront(shovel,5);
                
        Debug.Log("Spawned Shovel!");
    }
    
    public void spawnLocator()
    {
        SpawnInFront(locator,0.3f);
                
        Debug.Log("Spawned Locator!");
    }
    private void SpawnInFront(GameObject thing, float distance)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion Rotation = player.transform.rotation;
        float spawnDistance = distance;
            
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;

        thing.transform.position = spawnPos;
        thing.transform.rotation = Rotation;
        //face the thing towards the player
        thing.transform.rotation *= Quaternion.Euler(0, 180, 0);
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

