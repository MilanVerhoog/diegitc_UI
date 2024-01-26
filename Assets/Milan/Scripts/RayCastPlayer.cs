using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        print(cam.name);

    }

    // Update is called once per frame
    void Update()
    {
        // Draw Ray
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 100f;
        mousepos = cam.ScreenToWorldPoint(mousepos);
        Debug.DrawRay(transform.position, mousepos - transform.position, Color.cyan);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Input.GetMouseButtonDown(0);
        }

        
    }
}
