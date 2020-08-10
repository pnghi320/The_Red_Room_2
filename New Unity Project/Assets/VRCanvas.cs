using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour
{
    //the button that is being pressed, if no button is pressed, this will be null
    public GazeableButton currentActiveButton;


    //set the color for selected and unselected button
    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
    //basically change the color of the button
    public void SetActiveButton(GazeableButton activeButton){
        //if there was a previous selected button, change its color to white before change other button color to green.
        if (currentActiveButton != null){
            currentActiveButton.SetButtonColor(unselectedColor);
        }

        //if we are not selecting a button twice
        if (activeButton != null && currentActiveButton != activeButton){
            //save the button being pressed as currentActiveButton for other method calls;
            currentActiveButton = activeButton;
            //Set the color to green because the button is selected
            currentActiveButton.SetButtonColor(selectedColor);
        }
        else {
            //happen when you press a button twice, print the debug message and unselect the button
            Debug.Log("Resetting");
            //no button is being pressed
            currentActiveButton = null;
            //set the mode of the player to NONE
            Player.instance.activeMode = InputMode.NONE;
        }
    }

    public void LookAtPlayer(){
        //get access to player position at the moment
        Vector3 playerPos = Player.instance.transform.position;
        //distance from the panel to the player. transform.position is the postion of the pannel because this file is attached to the canvas 
        Vector3 vecToPlayer = playerPos - transform.position;
        // since the "eye" of the pannel is at the back side, lookatPos, which is the position that we force the pannel to look at
        // is equal to 2*the distance between the player and the panel (= transform.position - vecToPlayer) so that the point is now behind the 
        //pannel and the eye from the back can look at it.  
        Vector3 lookAtPos = transform.position - vecToPlayer;
        //make the eye look at the point.
        transform.LookAt(lookAtPos);

    }


}
