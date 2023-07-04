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
    [SerializeField] private GameObject probe;
    [SerializeField] private GameObject glove;
    [SerializeField] private GameObject rightSnowpile;
    

    //[SerializeField]private PostProcessProfile sunGlassProfile;
    //[SerializeField]private PostProcessProfile startProfile;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawnShovel()
    {
        SpawnInFront(shovel,0.8f);
                
        Debug.Log("Spawned Shovel!");
    }
    
    public void spawnLocator()
    {
        SpawnInFront(locator,0.3f);
                
        Debug.Log("Spawned Locator!");
    }

    public void spawnProbe()
    {
        SpawnInFront(probe,1f);
        probe.transform.rotation = Quaternion.Euler(90,90,0);        
        Debug.Log("Spawned Probe!");
    }

    public void spawnMarker()
    {
        Vector3 pilePos = rightSnowpile.transform.position;
        Vector3 spawnPos = pilePos;

        glove.transform.position = spawnPos + Vector3.up*0.3f;
        Debug.Log("Spawned Marker!");
        InventoryController.closeInventory();

    }
    private void SpawnInFront(GameObject thing, float distance)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion Rotation = player.transform.rotation;
            
        Vector3 spawnPos = playerPos + playerDirection* distance;
    
        thing.transform.position = spawnPos;
        thing.transform.rotation = Rotation;
        //face the thing towards the player
        thing.transform.rotation *= Quaternion.Euler(0, 180, 0);
        
        Debug.Log(thing);
        Debug.Log(spawnPos);
        Debug.Log(Rotation);

        InventoryController.closeInventory();
    }

    
    public void PutOnSunGlasses()
    { 
        Debug.Log("Put On Glasses!");
        //deactivate LightSources
        
        //change Postprocessing Filters

    }
}

