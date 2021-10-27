using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private UnityEvent OnAllLifeLosted;
    [SerializeField] private UnityEvent OnLifeLosted;
    [SerializeField] private UnityEventInt UiUpdate;
    private int _life = 3;

    private void OnEnable()
    {
        BallCount.OnEnded += LostLife;
    }

    private void OnDisable()
    {
        BallCount.OnEnded -= LostLife;
    }

    private void LostLife()
    {
        if(_gameState.State == State.GamePlay)
        {
            _life--;
            if(_life < 1)
            {
                OnAllLifeLosted.Invoke();
            }
            else
            {
                OnLifeLosted.Invoke();
            }
            UiUpdate.Invoke(_life); 
        }
    }
}
[System.Serializable]
public class UnityEventInt : UnityEvent<int> { }


