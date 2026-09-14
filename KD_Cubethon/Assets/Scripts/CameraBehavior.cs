using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public Vector3 offset;

    public bool gameWon = false;
    public bool gameLost = false;

    void Update()
    {

        if(!gameWon && !gameLost)
        {

            transform.position = ((player1.position + player2.position) / 2) + offset;

        }

    }

}
