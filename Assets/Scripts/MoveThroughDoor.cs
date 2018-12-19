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

        }
    }

}
