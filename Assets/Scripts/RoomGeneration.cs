using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour {

    public GameObject room, roomHolder;
    public int maxRooms;
    public int roomsCreated;
    public float roomHeight, roomWidth;
    public List<Vector2> placedRoomsCoords;
    Vector2 spawnCoordinates;
    GameObject player;

    bool playerSpawned = false;
    bool canGenerate;
    public bool fullyGenerated;

	void Start ()
    {
        fullyGenerated = false;
        spawnCoordinates = transform.position;
        placedRoomsCoords = new List<Vector2>(maxRooms);
        InstantiateRoom();
        canGenerate = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void InstantiateRoom()
    {
        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
        placedRoomsCoords.Add(spawnCoordinates); //adds the coordinates of the room to the list
        roomsCreated++;
    }

    private void Update()
    {
        if(!playerSpawned && fullyGenerated)
        {
            playerSpawned = true;
            player.SetActive(true);
        }
    }
    public void GenerateRooms()
    {
        //This is how I was originally generating my rooms but this would cause the dungeon to go in a single direction and didn't allow for much variety.
        if (canGenerate == true)
        {
            do
            {
                int roomDir = Random.Range(0, 4);
                
                if(roomsCreated >= maxRooms)
                {
                    canGenerate = false;
                }
                //make into switch statement.
                if (roomDir == 0 )
                {
                    spawnCoordinates.y += roomHeight; //Makes the next room spawn above the current.
                    if (!placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates); //adds the coordinates of the room to the list
                        roomsCreated++;
                    }
                }
                if (roomDir == 1 )
                {
                    spawnCoordinates.y -= roomHeight; //Makes the next room spawn below the current.
                    if (!placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;
                    }
                }
                if (roomDir == 2)
                {
                    spawnCoordinates.x += roomWidth; //Makes the next room spawn to the right of the current.
                    if (!placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;
                    }
                }
                if (roomDir == 3 )
                {
                    spawnCoordinates.x -= roomWidth; //Makes the next room spawn to the left of the current.
                    if (!placedRoomsCoords.Contains(spawnCoordinates))
                    {
                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;
                    }
                }
            }
            while (roomsCreated < maxRooms);
        }
    }



     // How I was previously making it not spawn a room ontop of another room. Using directional bools
     //I chose to not use this due to it creating lots of framerate issues as well as giving an undesirable final outcome.
    /*

     * 
     *
    void GenerateRooms()
    {
        if (canGenerate == true)
        {
            do
            {
                int roomDir = Random.Range(0, 4);


                if (roomsCreated >= maxRooms)
                {
                    canGenerate = false;
                }
                //make into switch statement.
                if (roomDir == 0 && up == false)
                {
                    up = false;
                    down = true;
                    left = false;
                    right = false;

                    spawnCoordinates.y += roomHeight; //Makes the next room spawn above the current.

                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates); //adds the coordinates of the room to the list
                        roomsCreated++;

                }
                if (roomDir == 1 && down == false)
                {
                    up = true;
                    down = false;
                    left = false;
                    right = false;

                    spawnCoordinates.y -= roomHeight; //Makes the next room spawn below the current.

                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;

                }
                if (roomDir == 2 && left == false)
                {
                    up = false;
                    down = false;
                    left = true;
                    right = false;

                    spawnCoordinates.x += roomWidth; //Makes the next room spawn to the right of the current.

                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;

                }
                if (roomDir == 3 && right == false)
                {
                    up = false;
                    down = false;
                    left = false;
                    right = true;

                    spawnCoordinates.x -= roomWidth; //Makes the next room spawn to the left of the current.
                        Instantiate(room, spawnCoordinates, Quaternion.identity, roomHolder.transform);
                        placedRoomsCoords.Add(spawnCoordinates);
                        roomsCreated++;
                }
            }
            while (roomsCreated < maxRooms);
        }
    }*/
}
