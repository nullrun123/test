using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool GameIsOver;

    public GameObject gameoverUi;

     void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
            return;

        //if (Input.GetKeyDown("e"))
        //{
            //Endgame();
        //}
        if(PlayerState.Lives <= 0)
        {
            Endgame();
        }
    }
    void Endgame()
    {
        GameIsOver = true;
        Debug.Log("Game over!");

        gameoverUi.SetActive(true);
    }
}
