using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEventInt UiUpdate;
    private int _score = 0;

    public void SetDefault()
    {
        _score = 0;
        UiUpdate.Invoke(_score);
    }

    public void OnEnable()
    {
        Block.OnDestroyed += ScoreCollect;
        Bonus.OnAdded += ScoreCollect;
    }

    public void OnDisable()
    {
        Block.OnDestroyed -= ScoreCollect;
        Bonus.OnAdded -= ScoreCollect;
    }

    private void ScoreCollect(int value)
    {
        if(_gameState.State == State.GamePlay)
        {
            _score += value;
            UiUpdate.Invoke(_score);
        }
    }
}
