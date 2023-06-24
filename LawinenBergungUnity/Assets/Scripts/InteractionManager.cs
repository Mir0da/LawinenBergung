using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    
    private Interaction currentInteraction;
    private int interactionIndex;
    private Camera cam;
    private int errorCount;
    private int helpCount;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
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
            if (Input.GetMouseButtonDown(0))
            {
                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    CheckInteractionOrder(result.gameObject);
                    Debug.Log("Hit " + result.gameObject.name);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            helpCount++;
            helpCountLabel.SetText("Hilfen: " + helpCount.ToString());
            
            StopDisplay();
            StartCoroutine(DisplayForDuration(helpLabel, currentInteraction.HelpMsg, 5.0f));

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
}
