using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Suchgerät : MonoBehaviour
{
    [SerializeField] private GameObject sonde;
    [SerializeField] private TextMeshProUGUI meterAnzeige;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position,sonde.transform.position);
        meterAnzeige.SetText(distance.ToString());
    }
}
