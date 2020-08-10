using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloseButton : GazeableButton
{
    public GameObject canvas;
    //override the OnPress method in GazeableButton
    public override void OnPress(RaycastHit hitInfo){
        //change the color of the button
        base.OnPress(hitInfo);
        //close the canvas if user hit close
        Destroy(canvas) ;

    }
}
