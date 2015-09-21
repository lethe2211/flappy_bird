﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    
    enum State
    {
        Ready,
        Play,
        GameOver
    }
    
    State state;
    int score;
    
    public AzarashiController azarashi;
    public GameObject blocks;
    public Text scoreLabel;
    public Text stateLabel;    

    void Start()
    {
        Ready();
    }
    
    void LateUpdate ()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetButtonDown("Fire1")) 
                {
                    GameStart();
                }
                break;
            case State.Play:
                if (azarashi.IsDead())
                {
                    GameOver();
                }
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Fire1"))
                {
                    Reload();
                }
                break;
        }
    }

    void Ready ()
    {
        state = State.Ready;
        
        // Disable game objects
        azarashi.SetSteerActive(false);
        blocks.SetActive(false);
        
        scoreLabel.text = "Score : " + 0;
        
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready"; 
    }
    
    void GameStart ()
    {
        state = State.Play;
        azarashi.SetSteerActive(true);
        blocks.SetActive(true);
        azarashi.Flap();
        
        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }
    
    void GameOver ()
    {
        state = State.GameOver;
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject so in scrollObjects)
        {
            so.enabled = false;
        }
        
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }
    
    void Reload ()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    public void IncreaseScore ()
    {
        score++;
        scoreLabel.text = "Score : " + score;
    }

}
