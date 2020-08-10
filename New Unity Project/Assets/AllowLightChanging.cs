//attached to door
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowLightChanging : MonoBehaviour
{
    public Light Light01;
    public Light Light02;
    public Light Light03;
    public bool doorIsOpen = false;
    public GameObject winnerNotice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Light01.color == Color.black && Light02.color == Color.red && Light03.color == Color.yellow && doorIsOpen == false){
            
            
            //access to the object current rotation of the moment
            Vector3 currentObjectRotation = transform.rotation.eulerAngles;
            if (doorIsOpen == false){
                //create the variable that hold the new position of the object being rotated
                Vector3 newRotation = new Vector3(currentObjectRotation.x, currentObjectRotation.y + 90f ,currentObjectRotation.z);
                //assign the new rotation to the obj's rotation.
                transform.rotation = Quaternion.Euler(newRotation);
                //since the door is now open
                doorIsOpen = true;
                winnerNotice.SetActive(true);
                }
        }
    }
}
