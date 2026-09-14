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

    private Invoker _invoker;

    private void Start()
    {
        _invoker = FindObjectOfType<Invoker>();
        _invoker.refresh(this);
    }

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

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 100));
        if (!_invoker._isRecording && !_invoker._isReplaying)
        {
            if (GUILayout.Button("Start Recording"))
            {
                Restart();
                _invoker._isReplaying = false;
                _invoker._isRecording = true;
                _invoker.Record();
            }
        }

        if (_invoker._isRecording)
        {
            if (GUILayout.Button("Stop Recording"))
            {
                Restart();
                _invoker._isRecording = false;
            }
        }

        if (!_invoker._isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                _invoker._isRecording = false;
                _invoker._isReplaying = true;
                Restart();
            }
        }
        GUILayout.EndArea();
    }

}
