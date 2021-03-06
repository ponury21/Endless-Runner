﻿using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance{
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    protected GameManager(){
        GameState = GameState.Start;
    }

    public GameState GameState { get; set; } 
    public void Die(){
            this.GameState = GameState.Dead; 
            UIManager.Instance.showHighScores();
    }
    public void Pause(){
        this.GameState=GameState.Pause;
        UIManager.Instance.showUIPause();
    }
    public void Play(){
        this.GameState=GameState.Playing;
        UIManager.Instance.hideUI();
    }
    public void Start(){
        this.GameState=GameState.Start;
        UIManager.Instance.showUIStart();
    }
}
