//attached to the main camera
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PositionCheckpoint : MonoBehaviour
{
    //inherent from GazeableObject 
    private GazeableObject currentGazeObject;
    //check if the object is placed in the correct place to complete the first puzzle 
    public bool isInPlace;
    void FixedUpdate()
    {
        //make a raycast
        Ray raycastRay = new Ray (transform.position, transform.forward);
        RaycastHit hitInfo;
        //raycastRay.direction * 100 because raycastRay.direction is just a very small unit
        Debug.DrawRay (raycastRay.origin, raycastRay.direction * 100);
        if(Physics.Raycast(raycastRay, out hitInfo))
        {
            // Get the GameObject from the hitInfo
            GameObject hitObj = hitInfo.collider.gameObject;

            // Get the GazeableObject from the hit Object, if the obj is not gazable, gazeObj will be NULL
            GazeableObject gazeObj = hitObj.GetComponentInParent<GazeableObject>();

            if (gazeObj != null) 
            {
                // Check if object we're looking at is different from the one we've been looking
                if (gazeObj != currentGazeObject) 
                {
                    //clear the old obj
                    ClearCurrentObject ();
                    //assign the new one
                    currentGazeObject = gazeObj;
                    //call the OnRaycastEnter function in the gazeableObject
                    currentGazeObject.OnRaycastEnter(hitInfo);
                    
                    //if we put the table in the right place
                    if (gameObject.name == "RayCast3" || gameObject.name == "RayCast1" || gameObject.name == "RayCast2"){
                        if (currentGazeObject.name == "desk(Clone)")
                        {
                        isInPlace = true;
                        }
                        else {
                            isInPlace = false;
                        }
                    }
                    //if we put the number 1 picture in the right place
                    if(gameObject.name == "RayCast2a" || gameObject.name == "RayCast2c"){
                        if (currentGazeObject.name != "Number1")
                        {
                        isInPlace = false;
                        }
                        else if (currentGazeObject.name == "Number1"){
                            isInPlace = true;
                        }
                    }
                    //if we put the number 2 picture in the right place
                    if(gameObject.name == "RayCast2b" || gameObject.name == "RayCast2d"){
                        if (currentGazeObject.name != "Number2")
                        {
                        isInPlace = false;
                        }
                        else if (currentGazeObject.name == "Number2"){
                            isInPlace = true;
                        }
                    }

                } 
                else 
                {
                    //if we keep looking at the same object, call the OnGaze function
                    currentGazeObject.OnRaycastHold(hitInfo);
                }
            }
            else 
            {
                //if we're not looking at a gazeable object
                ClearCurrentObject ();
            }
        }
        else 
        {
            //if we're not looking at anything
            ClearCurrentObject ();
        }
    }

    private void ClearCurrentObject()
    {
        if(currentGazeObject != null){
            //finish looking at the current obj
            currentGazeObject.OnGazeExit();
            //clear the current currentGazeObject
            currentGazeObject = null;
        }
    }
}