using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject shovelPrefab;
    [SerializeField] private GameObject probePrefab;
    [SerializeField] private GameObject locatorPrefab;
    [SerializeField] private GameObject markerPrefab;
    
    [SerializeField] private Button shovelButton;
    [SerializeField] private Button locatorButton;
    [SerializeField] private Button probeButton;
    [SerializeField] private Button sunglassesButton;
    [SerializeField] private Button markerButton;
    
    //[SerializeField]private PostProcessProfile sunGlassProfile;
    //[SerializeField]private PostProcessProfile startProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        shovelButton.onClick.AddListener(delegate { SpawnInFront(shovelPrefab); });
        probeButton.onClick.AddListener(delegate { SpawnInFront(probePrefab); });
        locatorButton.onClick.AddListener(delegate { SpawnInFront(locatorPrefab); });
        
        sunglassesButton.onClick.AddListener(delegate { PutOnSunGlasses(); });
        markerButton.onClick.AddListener(delegate { PlaceMarker(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnInFront(GameObject prefab)
    { 
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;
            
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
            
        Debug.Log("Spawned Shovel!");
        Instantiate(prefab, spawnPos, playerRotation);
    }
    
    public void PlaceMarker()
    { 
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;
            
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
            
        Debug.Log("Spawned Marker!");
        Instantiate(markerPrefab, spawnPos, playerRotation);
    }
    
    public void PutOnSunGlasses()
    { 
        Debug.Log("Put On Glasses!");
        //deactivate LightSources
        
        //change Postprocessing Filters

    }
}
