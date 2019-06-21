﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Player player;

    public float resetTimer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.SegurandoBola == false)
        {
            resetTimer -= Time.deltaTime;
            Debug.Log(resetTimer);
            if(resetTimer <= 0)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
