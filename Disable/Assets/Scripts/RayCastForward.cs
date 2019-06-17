using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForward : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        float theDistance;
        // Debug raycast in the editor - SO WE CAN SEE IT! MAKES LIFE EASIER!
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out Hit)) {
            theDistance = Hit.distance;
            print(theDistance + " " + Hit.collider.gameObject.name);
        }
    }
}
