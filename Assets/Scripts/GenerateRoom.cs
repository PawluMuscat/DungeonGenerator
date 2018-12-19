using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour {

    RoomGeneration roomGeneration;

    public enum direction
    {
        North,
        East,
        South,
        West
    }

    public direction previousDir;

    Vector2 spawnCoordinates;
    public int roomsSpawned, roomsToSpawn;

	void Start ()
    {
        spawnCoordinates = transform.position;
        roomGeneration = GameObject.FindGameObjectWithTag("GenerationManager").GetComponent<RoomGeneration>();
        roomsToSpawn = AmountToSpawn();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Invoke("MakeRoom", .5f);
        
	}

    void MakeRoom()
    {
        if (roomGeneration.roomsCreated < roomGeneration.maxRooms)
        {
            if (roomsSpawned < roomsToSpawn)
            {
                direction chosenDir = ChooseDirection(); //Choose the direction to branch.
                
                if (chosenDir == direction.North)
                {
                    spawnCoordinates.y += roomGeneration.roomHeight; //Makes the next room spawn above the current.
                    if (!roomGeneration.placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        GameObject spawnedRoom = CreateRoom();
                        spawnedRoom.GetComponent<GenerateRoom>().previousDir = direction.North;
                    }
                    spawnCoordinates = transform.position; //Resets the spawn coordinates for the next itteration.
                }
                if (chosenDir == direction.South)
                {
                    spawnCoordinates.y -= roomGeneration.roomHeight; //Makes the next room spawn below the current.
                    if (!roomGeneration.placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        GameObject spawnedRoom = CreateRoom();
                        spawnedRoom.GetComponent<GenerateRoom>().previousDir = direction.South;
                    }
                    spawnCoordinates = transform.position;
                }
                if (chosenDir == direction.East)
                {
                    spawnCoordinates.x += roomGeneration.roomWidth; //Makes the next room spawn to the right of the current.
                    if (!roomGeneration.placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        GameObject spawnedRoom = CreateRoom();
                        spawnedRoom.GetComponent<GenerateRoom>().previousDir = direction.East;
                    }
                    spawnCoordinates = transform.position;
                }
                if (chosenDir == direction.West)
                {
                    spawnCoordinates.x -= roomGeneration.roomWidth; //Makes the next room spawn to the left of the current.
                    if (!roomGeneration.placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        GameObject spawnedRoom = CreateRoom();
                        spawnedRoom.GetComponent<GenerateRoom>().previousDir = direction.West;
                    }
                    spawnCoordinates = transform.position;
                }
            }
        }
        else
        {
            roomGeneration.fullyGenerated = true;
        }
    }

    //I Created this to replace repetative code and increase readability.
    GameObject CreateRoom()
    {
        GameObject spawnedRoom = Instantiate(roomGeneration.room, spawnCoordinates, Quaternion.identity, roomGeneration.roomHolder.transform);

        roomGeneration.placedRoomsCoords.Add(spawnCoordinates); //adds the coordinates of the room to the list
        roomGeneration.roomsCreated++;
        roomsSpawned++;

        return spawnedRoom;
    }

    //This chooses what direction the next room will branch to, this is used to make it more likely to branch out in the same direction as the previous room
    //this is to stop the dungeon from looking clunky and being a box.
    direction ChooseDirection()
    {
        int rng = Random.Range(0, (roomGeneration.maxRooms * 2));
        if(rng == 0)
            return direction.North;
        if (rng == 1)
            return direction.East;
        if (rng == 2)
            return direction.South;
        if (rng == 3)
            return direction.West;
        else
            return previousDir;
    }

    //This choses the amount of rooms to be branched from a single room.
    int AmountToSpawn()
    {
        int rng;
        //if its the first room make sure it spawns more than 1 room to make it more spread out.
        if (roomGeneration.roomsCreated == 1)
            rng = Random.Range(5, 11);

        else
            rng = Random.Range(1, 11);

        if (rng <= 4)
            return 1;
        if (rng > 4 && rng <= 7)
            return 2;
        if (rng > 7 && rng <= 9)
            return 3;
        else
            return 4;
    }


}
