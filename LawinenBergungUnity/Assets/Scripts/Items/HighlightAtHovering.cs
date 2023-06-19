using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightAtHovering : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    
    private Material[] defaultMaterials;
    private MeshRenderer meshRenderer;
    
    private void Awake() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();  //in children weil die Hitbox als Parent gesetzt werden kann
        defaultMaterials = meshRenderer.materials;
    }
    private void OnMouseEnter() {
        var materials = meshRenderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = highlightMaterial;
        }
        meshRenderer.materials = materials;
    }
    private void OnMouseExit() {
        meshRenderer.materials = defaultMaterials;
    }
    
    //Für mouse callbakcs brauchen die Obkjekte Collider!
}
