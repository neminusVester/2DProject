using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleSize : Bonus
{
    [SerializeField] private bool _negative;
    private const float Size = 0.7f;

    public override void Apply()
    {
        StartTimer();
        SetSize(_negative ? -Size : Size);
    }

    protected override void Remove()
    {
        SetSize(_negative ? Size : -Size);
    }

    private void SetSize(float value)
    {
        MovingPaddle paddle = GetComponentInParent<MovingPaddle>();
        if (paddle != null)
        {
            if(paddle.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.size = new Vector2(spriteRenderer.size.x + value, spriteRenderer.size.y);
            }
            if (paddle.TryGetComponent(out BoxCollider2D boxCollider2D))
            {
                boxCollider2D.size = new Vector2(boxCollider2D.size.x + value, boxCollider2D.size.y);
            }
        }
    }
}


