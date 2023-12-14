using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// highlights objects that the script's carrier object is pointing to
public class HighlightSelectedObject : MonoBehaviour
{
    // tags
    [SerializeField] private string arteryTag = "Artery";
    [SerializeField] private string boneTag = "Bone";
    [SerializeField] private string intestinesLightTag = "Intestines Light";
    [SerializeField] private string intestinesDarkTag = "Intestines Dark";
    [SerializeField] private string kidneysTag = "Kidneys";
    [SerializeField] private string lungsTag = "Lungs";
    [SerializeField] private string veinTag = "Vein";
    // default materials
    [SerializeField] private Material arteryMat;
    [SerializeField] private Material boneMat;
    [SerializeField] private Material intestinesLightMat;
    [SerializeField] private Material intestinesDarkMat;
    [SerializeField] private Material kidneysMat;
    [SerializeField] private Material lungsMat;
    [SerializeField] private Material veinMat;
    // highlight material
    [SerializeField] private Material highlightMaterial;

    private Transform _selection;

    private void Update(){
        // reset the material to its original state
        if (_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            // artery
            if(selectionRenderer.CompareTag(arteryTag)){
                selectionRenderer.material = arteryMat;
            }
            // bones
            if(selectionRenderer.CompareTag(boneTag)){
                selectionRenderer.material = boneMat;
            }
            // intestines light
            if(selectionRenderer.CompareTag(intestinesLightTag)){
                selectionRenderer.material = intestinesLightMat;
            }
            // intestines dark
            if(selectionRenderer.CompareTag(intestinesDarkTag)){
                selectionRenderer.material = intestinesDarkMat;
            }
            // kidneys
            if(selectionRenderer.CompareTag(kidneysTag)){
                selectionRenderer.material = kidneysMat;
            }
            // lungs
            if(selectionRenderer.CompareTag(lungsTag)){
                selectionRenderer.material = lungsMat;
            }
            // vein
            if(selectionRenderer.CompareTag(veinTag)){
                selectionRenderer.material = veinMat;
            }
            _selection = null;
        }
        // deploy a ray from the laparoscope tip
        var ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        // on ray hit set the material to the highlighted one
        if (Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            if (selection.CompareTag(arteryTag)||selection.CompareTag(boneTag)||selection.CompareTag(intestinesLightTag)||selection.CompareTag(intestinesDarkTag)||selection.CompareTag(kidneysTag)||selection.CompareTag(lungsTag)||selection.CompareTag(veinTag)){
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null){
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
            }
            
        }
    }
}
