using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameState _gameState;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        _gameState.SetState(State.GamePlay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
