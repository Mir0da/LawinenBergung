using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject overviewInventory;
    [SerializeField] private GameObject cam;

    public static bool isClosed;
    
    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isClosed)
            {
                //toggle Inventories
                isClosed = false;
                inventory.SetActive(true);
                overviewInventory.SetActive(false);
                
                //make Mouse visible and useable
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                //disable Cam Movement
                cam.GetComponent<FirstPersonCam>().enabled = false;
                cam.GetComponent<RaycasterFirstPersonCam>().enabled = false;
                //disable playermovement too?
                //player.GetComponent<MovePlayer>().enabled = true;
            }
            else
            {
                //toggle Inventories
                isClosed = true;
                inventory.SetActive(false);
                overviewInventory.SetActive(true);
                
                //hide Mouse
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //enable Cam Movement
                cam.GetComponent<FirstPersonCam>().enabled = true;
                cam.GetComponent<RaycasterFirstPersonCam>().enabled = true;
                //disable playermovement too?
                //player.GetComponent<MovePlayer>().enabled = true;
            }
        }
    }
}
