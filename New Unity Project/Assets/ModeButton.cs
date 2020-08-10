using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : GazeableButton
{
    //SerializeField makes private or protected variables visible in the inspector, so that we can still change it in unity 
    [SerializeField]
    private InputMode mode;
    //override the OnPress method in GazeableButton
    public override void OnPress(RaycastHit hitInfo){
        base.OnPress(hitInfo);
        //if we are not pressing on the same button twice in a row
        if(parentPanel.currentActiveButton != null){
            //set the mode as the button indicate
            Player.instance.activeMode = mode;
        }
    }
}
