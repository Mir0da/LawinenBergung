using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RaycasterFirstPersonCam : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private TextMeshProUGUI info;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 20.0f, layerMask)) //20= länge des Strahls
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                info.SetText(hit.transform.GameObject().name);
            }
        }
    }
}
