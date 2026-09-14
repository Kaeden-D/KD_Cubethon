using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{

    bool gameOver = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public PlayerMovement1 player1;
    public PlayerMovement2 player2;

    public void CompleteLevel()
    {

        completeLevelUI.SetActive(true);

    }
    
    public void EndGame()
    {

        if (!gameOver)
        {

            gameOver = true;
            Debug.Log("GameOver");
            Invoke("Restart", restartDelay);

        }

    }

    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Cheat()
    {

        player1.Cheat();
        player2.Cheat();

    }

    private void FixedUpdate()
    {

        if (Input.GetKey("r"))
        {

            Invoke("Restart", 0.2f);

        }

        if (Input.GetKey("c"))
        {

            Invoke("Cheat", 0.2f);

        }

    }

}
