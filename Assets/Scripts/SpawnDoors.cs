using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour {

    RoomGeneration roomGeneration;
    List<Vector2> roomsCoords;
    float roomHeight, roomWidth;
    float doorHeight, doorWidth;
    SpriteRenderer doorSR;
    public GameObject topDoor, rightDoor, leftDoor, bottomDoor;
    bool topChecked, rightChecked, leftChecked, bottomChecked, allChecked;
    public GameObject doorHolder;

    private void Start()
    {
        doorSR = topDoor.GetComponentInChildren<SpriteRenderer>();
        roomGeneration = gameObject.GetComponent<RoomGeneration>();
        roomHeight = roomGeneration.roomHeight;
        roomWidth = roomGeneration.roomWidth;
        doorHeight = doorSR.bounds.size.y;
        doorWidth = doorSR.bounds.size.x;
    }

    private void Update()
    {
        if (roomGeneration.fullyGenerated && !allChecked)
        {
            roomsCoords = roomGeneration.placedRoomsCoords;
            CreateDoors();
        }
    }

    void CreateDoors()
    {
        //Gets the location of each room and checks the list to see if there's a room placed on the coordinates in each of the 4 directions
        //when a room is found in one of the directions the corrisponding door is placed.
        foreach (Vector2 roomCoord in roomsCoords)
        {
            topChecked = false;
            leftChecked = false;
            rightChecked = false;
            bottomChecked = false;

            if (CheckAboveRoom(roomCoord) && !topChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.y += (roomHeight / 2) - (doorHeight / 2);
                GameObject door = Instantiate(topDoor,doorHolder.transform);
                door.transform.position = tempRoomCoord;
                topChecked = true;
            }
            if (CheckBelowRoom(roomCoord) && !bottomChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.y -= (roomHeight / 2) - (doorHeight / 2);
                GameObject door = Instantiate(bottomDoor, doorHolder.transform);
                door.transform.position = tempRoomCoord;
                bottomChecked = true;
            }
            if(CheckLeftOfRoom(roomCoord) && !leftChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.x -= (roomWidth / 2) - (doorWidth / 2);
                GameObject door = Instantiate(leftDoor, doorHolder.transform);
                door.transform.position = tempRoomCoord;
                leftChecked = true;
            }
            if(CheckRightOfRoom(roomCoord) && !rightChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.x += (roomWidth / 2) - (doorWidth / 2);
                GameObject door = Instantiate(rightDoor, doorHolder.transform);
                door.transform.position = tempRoomCoord;
                rightChecked = true;
            }
        }
        allChecked = true;
    }

    bool CheckAboveRoom(Vector2 roomCoord)
    {
        Vector2 tempRoomCoord = roomCoord;
        tempRoomCoord.y += roomHeight;
        if (roomsCoords.Contains(tempRoomCoord))
            return true;
        else
            return false;
    }

    bool CheckBelowRoom(Vector2 roomCoord)
    {
        Vector2 tempRoomCoord = roomCoord;
        tempRoomCoord.y -= roomHeight;
        if (roomsCoords.Contains(tempRoomCoord))
            return true;
        else
            return false;
    }

    bool CheckRightOfRoom(Vector2 roomCoord)
    {
        Vector2 tempRoomCoord = roomCoord;
        tempRoomCoord.x += roomWidth;
        if (roomsCoords.Contains(tempRoomCoord))
            return true;
        else
            return false;
    }

    bool CheckLeftOfRoom(Vector2 roomCoord)
    {
        Vector2 tempRoomCoord = roomCoord;
        tempRoomCoord.x -= roomWidth;
        if (roomsCoords.Contains(tempRoomCoord))
            return true;
        else
            return false;
    }
}
