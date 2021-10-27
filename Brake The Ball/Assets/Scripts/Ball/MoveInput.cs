using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveInput : MonoBehaviour
{
    public static event Action OnPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnPressed?.Invoke();
        }
    }
}
