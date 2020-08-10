using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButton : GazeableButton
{
    //prefab that is associated with the furniture button
    public Object prefab;
    //do all of the stuff in the OnPress function in the GazeableButton file
    public override void OnPress(RaycastHit hitInfo){
        //change the color of the button
        base.OnPress(hitInfo);
        //set player mode to: Place Furniture
        Player.instance.activeMode = InputMode.FURNITURE;
        //set active furniture prefab to this prefab to let the program knows what type is the furniture that he's using
        Player.instance.activeFurniturePrefab = prefab;
    

    }
}
