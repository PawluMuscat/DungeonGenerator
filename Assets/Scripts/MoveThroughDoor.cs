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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (doorPlacement == placement.Top)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.y += 3;
                collision.transform.position = playerPos;
                print("hit door");
            }
            else if (doorPlacement == placement.Bottom)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.y -= 3;
                collision.transform.position = playerPos;
            }
            else if (doorPlacement == placement.Right)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.x += 3;
                collision.transform.position = playerPos;
            }
            else if (doorPlacement == placement.Left)
            {
                Vector3 playerPos = collision.transform.position;
                playerPos.x -= 3;
                collision.transform.position = playerPos;
            }
        }
    }

}
