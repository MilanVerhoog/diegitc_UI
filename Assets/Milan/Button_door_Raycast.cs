using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_door_Raycast : MonoBehaviour
{
    [SerializeField] private int raylength = 5;
    [SerializeField] private LayerMask LayermaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private Button_Door_controller raycastedobj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    

    private const string interactableTag = "DoorButton";

    private void Update()
    {

        
        
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | LayermaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, raylength, mask))
        {
            if(hit.collider.CompareTag(interactableTag))
            {
                if(!doOnce)
                {
                    raycastedobj = hit.collider.gameObject.GetComponent<Button_Door_controller>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = false;

                if(Input.GetKeyDown(openDoorKey))
                {
                    raycastedobj.PlayAnimation();

                }

                
            }

        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
               
          
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
            
        }

    }
}
