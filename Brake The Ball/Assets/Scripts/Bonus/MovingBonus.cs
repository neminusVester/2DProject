using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBonus : MonoBehaviour
{
    private const float Speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
}
