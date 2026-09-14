using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public LevelCompleteBehavior level_complete;

    public void StartGame()
    {

        Debug.Log("Game Started");
        level_complete.InvokeNextLevel(0.2f);

    }

}
