using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private TextMeshProUGUI errorCountLabel;
    [SerializeField] private TextMeshProUGUI helpCountLabel;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<Interaction> interactions;

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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
            {
                CheckInteractionOrder(hit.transform.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            helpCount++;
            helpCountLabel.SetText(helpCount.ToString());
            
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
            errorCountLabel.SetText(errorCount.ToString());
            
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
