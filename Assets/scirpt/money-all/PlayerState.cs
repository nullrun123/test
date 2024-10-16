using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int money;
    public int startMoney = 99999999;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;
    void Start()
    {

        money = startMoney;
        Lives = startLives;
        Rounds = -1;
    }
}
