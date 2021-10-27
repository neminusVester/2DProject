using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class WindowController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _playButton;

    public void Play()
    {
        _gameState.SetState(State.GamePlay);
        _pauseWindow.SetActive(false);
    }

    public void Replay()
    {
        DisableTwoWindow();
        SetActivePlay();
    }

    public void GoHome()
    {
        DisableTwoWindow();
        SceneManager.LoadScene("MainMenu");
    }

    private void DisableTwoWindow()
    {
        _endGameWindow.SetActive(false);
        _pauseWindow.SetActive(false);
    }
    public void SetActivePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameState.SetState(State.GamePlay);
    }

    private void OnEnable()
    {
        Block.OnEnded += EndGame;
    }
    
    private void OnDisable()
    {
        Block.OnEnded -= EndGame;
    }

    private void EndGame()
    {
        if(_gameState.State == State.GamePlay)
        {
            _endGameWindow.SetActive(true);
            _playButton.SetActive(false);
        }
    }
}
