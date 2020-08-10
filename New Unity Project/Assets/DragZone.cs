using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//the way we make it work is that we will take this parentPanel and turn camera main into its parent 
//make it a gazeable object and not a button because we dont need it to change its color
public class DragZone : GazeableObject
{
    private VRCanvas parentPanel;
    //going to set the player mode to drag, but we want to restore the original , initialize the variable with NONE for now 
    private InputMode savedInputMode = InputMode.NONE;
    //restore the parentpanel original parent (after we change its parent to the main camera to change the position)
    private Transform originalParent;



    // Start is called before the first frame update
    void Start()
    {
        //set the parentPanel first
        parentPanel = GetComponentInParent<VRCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //since this class inherents from GazeableObject, we can call the Onpress function in GazeableObject
    public override void OnPress(RaycastHit hitInfo){
        base.OnPress(hitInfo);
        //save the original parent
        originalParent = parentPanel.transform.parent;
        //make the entire canvas the child of main camera to move with it
        parentPanel.transform.parent = Camera.main.transform;
        
        //save the old input mode and set the current one to drag
        savedInputMode = Player.instance.activeMode;
        Player.instance.activeMode = InputMode.DRAG;
    }

    public override void OnRelease(RaycastHit hitInfo){
        base.OnRelease(hitInfo);
        //set everything back to normal
        parentPanel.transform.parent = originalParent;
        Player.instance.activeMode = savedInputMode;
    }

}
