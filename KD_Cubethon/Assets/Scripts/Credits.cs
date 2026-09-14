using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Complete_Restart()
    {

        Debug.Log("Game Restarted");
        Invoke("Restart", 0.2f);

    }

    public void Restart()
    {

        SceneManager.LoadScene(0);

    }

}
