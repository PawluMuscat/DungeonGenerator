using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int doorDir;
    /*
     * #1 = Bottom
     * #2 = Left
     * #3 = Right
     * #4 = Top
     */


    private RoomTemplates roomTemplates;
    private int randNum;
    private int maxRooms;
    private int currentRooms;

    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        //Change to a Switch Statement
        if (doorDir == 1)
        {
            randNum = Random.Range(0, roomTemplates.bottomDoors.Count);
            Instantiate(roomTemplates.bottomDoors[randNum], transform.position, roomTemplates.bottomDoors[randNum].transform.rotation);
            //Spawn a Room with a Bottom Door.
        }
        if (doorDir == 2)
        {
            randNum = Random.Range(0, roomTemplates.leftDoors.Count);
            Instantiate(roomTemplates.leftDoors[randNum], transform.position, roomTemplates.leftDoors[randNum].transform.rotation);
            //Spawns a Room with a Left Door.
        }
        if (doorDir == 3)
        {
            randNum = Random.Range(0, roomTemplates.rightDoors.Count);
            Instantiate(roomTemplates.rightDoors[randNum], transform.position, roomTemplates.rightDoors[randNum].transform.rotation);
            //Spawn a Room with a Right Door.
        }
        if (doorDir == 4)
        {
            randNum = Random.Range(0, roomTemplates.topDoors.Count);
            Instantiate(roomTemplates.topDoors[randNum], transform.position, roomTemplates.topDoors[randNum].transform.rotation);
            //Spawn a Room with a Top Door.
        }
    }
}

