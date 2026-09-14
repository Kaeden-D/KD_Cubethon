using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{

    public Transform player;
    public TextMeshProUGUI scoreText;

    bool allowTextChange = true;

    private void Update()
    {

        if (allowTextChange)
        {

            scoreText.text = player.position.z.ToString("0");

        }

    }

    public void textChange(bool change)
    {

        allowTextChange = change;

    }

}
