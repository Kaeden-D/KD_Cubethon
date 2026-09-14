using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerBehavior : MonoBehaviour
{

    public GameManger gameManager;
    public ScoreBehavior scoreBehavior;
    public LevelCompleteBehavior levelCompleteBehavior;
    public CameraBehavior cameraBehavior;

    public bool player1_enter = false;
    public bool player2_enter = false;

    private void OnTriggerEnter(UnityEngine.Collider collision)
    {

        if(collision.gameObject.name == "Player1")
        {

            player1_enter = true;

        }
        if(collision.gameObject.name == "Player2")
        {

            player2_enter = true;

        }

    }

    private void FixedUpdate()
    {

        if(player1_enter && player2_enter)
        {

            scoreBehavior.textChange(false);
            cameraBehavior.gameWon = true;
            gameManager.CompleteLevel();
            levelCompleteBehavior.InvokeNextLevel(3f);

        }

    }

}
