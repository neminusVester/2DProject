using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    GamePlay,
    StopGame,
    Other
}

public class GameState : MonoBehaviour
{
    public State State { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1f; 
    }

    public void SetState( State state)
    {
        State = state;
        if( State == State.StopGame)
        {
            Time.timeScale = 0;
            return;
        }
        else
        if (State == State.GamePlay || State == State.Other)
        {
            Time.timeScale = 1f;
        }
    }



}
