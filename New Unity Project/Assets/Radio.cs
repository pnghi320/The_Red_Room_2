using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    //create a variable to adjust the AudioSource setting
    AudioSource audio;
    //access the gameobject PositionCheckpoint to check their status
    public PositionCheckpoint checkpoint1;
    public PositionCheckpoint checkpoint2;
    public PositionCheckpoint checkpoint3;

    //access the gameobject PositionCheckpoint to check their status for the number puzzle
    public PositionCheckpoint checkpoint2a;
    public PositionCheckpoint checkpoint2b;
    public PositionCheckpoint checkpoint2c;
    public PositionCheckpoint checkpoint2d;


    public GameObject cabinetDoor;
    public GameObject tableDoor;

    //to check if the music has been played or not
    private bool musicOn = false;

    public bool tableDoorIsOpen = false;
    public bool cabinetDoorIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //assign the obj's audioSource to the audio variable
        audio = GetComponent<AudioSource>();
        

    }

   
    // Update is called once per frame
    void Update()
    {
        Vector3 currentTableDoorPostion = tableDoor.transform.rotation.eulerAngles;
        //if all 3 desk is placed in the right position
        if (checkpoint3.isInPlace && checkpoint2.isInPlace && checkpoint1.isInPlace){
            //if the music has not been played
            if (!musicOn)
            {
                //play the music
                GetComponent<AudioSource>().Play();
                //the music has been played
                musicOn = true;
                if (!tableDoorIsOpen){
                    Vector3 newRotation = new Vector3(currentTableDoorPostion.x, currentTableDoorPostion.y + 90f ,currentTableDoorPostion.z);
                    tableDoor.transform.rotation = Quaternion.Euler(newRotation);
                }
            }
            
        }

        Vector3 currentCabinetDoorPostion = cabinetDoor.transform.rotation.eulerAngles;
        //if all number pictures are placed in the right position
        if (checkpoint2a.isInPlace && checkpoint2b.isInPlace && checkpoint2c.isInPlace && checkpoint2d.isInPlace){
            //if the music has been played 
            //if (musicOn)
            if (musicOn)
            {
                //if the cabinet door is not open
                if (!cabinetDoorIsOpen){
                    Vector3 newRotation2 = new Vector3(currentCabinetDoorPostion.x, currentCabinetDoorPostion.y + 90f ,currentCabinetDoorPostion.z);
                    cabinetDoor.transform.rotation = Quaternion.Euler(newRotation2);
                    cabinetDoorIsOpen = true;

                }
            }
            
        }
    }
}
