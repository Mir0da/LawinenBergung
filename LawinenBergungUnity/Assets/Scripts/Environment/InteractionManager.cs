using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private TextMeshProUGUI errorCountLabel;
    [SerializeField] private TextMeshProUGUI helpCountLabel;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<Interaction> interactions;
    [SerializeField] private Canvas Inventory;
    
    [SerializeField] private TextMeshProUGUI itemName;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    
    private Interaction currentInteraction;
    private int interactionIndex;
    private Camera cam;
    private int errorCount;
    private int helpCount;
    private bool gotHelp;
    [HideInInspector]public static bool pause;
    [HideInInspector]public static bool ready;

    private void Awake()
    {
        cam = Camera.main;
 
    }

    private void Start()
    {
        interactionIndex = 0;
        errorCount = 0;
        helpCount = 0;
        gotHelp = false;
        pause = false;
        helpLabel.SetText("");
        errorLabel.SetText("");
        currentInteraction = interactions[interactionIndex];
        instructionLabel.SetText(currentInteraction.Instruction);
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = Inventory.GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        
        PlayerPrefs.SetInt("Help", helpCount);
        PlayerPrefs.SetInt("Error", errorCount);
        
        if (InventoryController.isClosed == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
                {
                    CheckInteractionOrder(hit.transform.gameObject);
                    Debug.Log("Hit " + hit.transform.gameObject);
                }
            }
        }
        else
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            
            foreach (RaycastResult result in results)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                    CheckInteractionOrder(result.gameObject);
                    Debug.Log("Hit " + result.gameObject.name);
                }
                itemName.SetText("" + result.gameObject.name.ToString());
            }
        }

        if (interactionIndex == interactions.Count || ready == true)
        {
            //all steps done
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gotHelp == false)
            {
                helpCount++;
                gotHelp = true;
            }
            
            helpCountLabel.SetText("Hilfen: " + helpCount.ToString());
            
            StopDisplay();
            StartCoroutine(DisplayForDuration(helpLabel, currentInteraction.HelpMsg, 5.0f));

        }

        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pause = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Pause_scene", LoadSceneMode.Additive);
        }
    }

    private void CheckInteractionOrder(GameObject selectedGameObject)
    {
        if (interactionIndex >= interactions.Count)
            return;

        if (selectedGameObject.Equals(currentInteraction.GameObject))
        {
            StopDisplay();
            currentInteraction.OnExecution?.Invoke();

            gotHelp = false;
            interactionIndex++;
            currentInteraction = interactions[interactionIndex];   
            instructionLabel.SetText(currentInteraction.Instruction);

        }
        else
        {
            errorCount++; 
            errorCountLabel.SetText("Fehler: " + errorCount.ToString());
            
            StartCoroutine(DisplayForDuration(errorLabel, currentInteraction.ErrorMsg, 5.0f));
        }
    }

    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        label.text = msg;
        yield return new WaitForSeconds(duration);
        label.text = "";
    }

    private void StopDisplay()
    {
        StopAllCoroutines();
        errorLabel.SetText("");
        helpLabel.SetText("");
    }

    public void setReady()
    {
        ready = true;
    }
}
