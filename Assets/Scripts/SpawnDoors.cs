using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour {

    RoomGeneration roomGeneration;
    List<Vector2> roomsCoords;
    int roomHeight, roomWidth;
    public GameObject topDoor, rightDoor, leftDoor, bottomDoor;
    bool topChecked, rightChecked, leftChecked, bottomChecked, allChecked;

    private void Start()
    {
        roomGeneration = gameObject.GetComponent<RoomGeneration>();
        roomHeight = roomGeneration.roomHeight;
        roomWidth = roomGeneration.roomWidth;
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
        foreach (Vector2 roomCoord in roomsCoords)
        {
            topChecked = false;
            leftChecked = false;
            rightChecked = false;
            bottomChecked = false;

            if (CheckAboveRoom(roomCoord) && !topChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.y += (roomHeight / 2)-1;
                GameObject door = Instantiate(topDoor,gameObject.transform);
                door.transform.position = tempRoomCoord;
                topChecked = true;
            }
            if (CheckBelowRoom(roomCoord) && !bottomChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.y -= (roomHeight / 2) -1 ;
                GameObject door = Instantiate(bottomDoor, gameObject.transform);
                door.transform.position = tempRoomCoord;
                bottomChecked = true;
            }
            if(CheckLeftOfRoom(roomCoord) && !leftChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.x -= (roomWidth / 2) -1;
                GameObject door = Instantiate(leftDoor, gameObject.transform);
                door.transform.position = tempRoomCoord;
                leftChecked = true;
            }
            if(CheckRightOfRoom(roomCoord) && !rightChecked)
            {
                Vector2 tempRoomCoord = roomCoord;
                tempRoomCoord.x += (roomWidth/2) - 1;
                GameObject door = Instantiate(rightDoor, gameObject.transform);
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
