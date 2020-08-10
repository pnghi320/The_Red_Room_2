using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to access the UI
using UnityEngine.UI;
//to make sure that the object has image component
[RequireComponent(typeof(Image))]

public class GazeableButton : GazeableObject
{
    //access the VRCanvas script
    protected VRCanvas parentPanel;

    // Start is called before the first frame update
    void Start()
    {
        //we create an object called parentPant that will store the information of the VRCanvas accessed using the GetComponent function
        parentPanel = GetComponentInParent<VRCanvas>(); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //function to set the color for our buttons
    public void SetButtonColor(Color buttonColor){
        //in the component named image, we access the color and change it
        GetComponent<Image>().color = buttonColor;
        //if the object does not have an image component then we have an exception

    }


    //Because we are the child of the GazeableObject we can override the function in such class
    public override void OnPress (RaycastHit hitInfo){
        //go the GazeableObject class and call the OnPress function
        base.OnPress(hitInfo);
        //we pressed on the button, now put that button into the SetActiveButton function in VRCanvas file which basically change the color of the button accordingly
        if (parentPanel != null){
            parentPanel.SetActiveButton(this);
        }
        else {
            Debug.LogError("Button is not a child or an object with VRPanel component", this);
        }
    }
}
