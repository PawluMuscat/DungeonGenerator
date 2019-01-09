using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughDoor : MonoBehaviour
{

    public enum placement
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public placement doorPlacement;


    Camera camera;
    RoomGeneration roomGeneration;
    float roomHeight, roomWidth;

    private void Start()
    {
        camera = Camera.main;
        roomGeneration = GameObject.FindGameObjectWithTag("GenerationManager").GetComponent<RoomGeneration>();
        roomHeight = roomGeneration.roomHeight;
        roomWidth = roomGeneration.roomWidth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Moves the player and the camera to the corrisponding room based on the door entered.
        if (collision.tag == "Player")
        {
            if (doorPlacement == placement.Top)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.y += 4;
                collision.transform.position = playerPos;
                Vector3 cameraPos = camera.transform.position;
                cameraPos.y += roomHeight;
                camera.transform.position = cameraPos;
            }
            else if (doorPlacement == placement.Bottom)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.y -= 4;
                collision.transform.position = playerPos;
                Vector3 cameraPos = camera.transform.position;
                cameraPos.y -= roomHeight;
                camera.transform.position = cameraPos;
            }
            else if (doorPlacement == placement.Right)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.x += 4;
                collision.transform.position = playerPos;
                Vector3 cameraPos = camera.transform.position;
                cameraPos.x += roomWidth;
                camera.transform.position = cameraPos;
            }
            else if (doorPlacement == placement.Left)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.x -= 4;
                collision.transform.position = playerPos;
                Vector3 cameraPos = camera.transform.position;
                cameraPos.x -= roomWidth;
                camera.transform.position = cameraPos;
            }
        }
    }

}
