using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAttach : MonoBehaviour
{
    [SerializeField] private MovingBonus _movingBonus;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Space]
    [SerializeField] private Bonus _bonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out MovingPaddle movingPaddle))
        {
            SetEnableBonus(false);
            Bonus[] bonuses = movingPaddle.gameObject.GetComponentsInChildren<Bonus>();
            if(bonuses.Length > 0)
            {
                foreach(var item in bonuses)
                {
                    if(_bonus.GetType() == item.GetType())
                    {
                        item.StopAndRemove();
                        break;
                    }
                }
                Attach(movingPaddle.transform);
            }
            else
            {
                Attach(movingPaddle.transform);
            }
        }
    }

    private void Attach(Transform parent)
    {
        transform.SetParent(parent);
        transform.position = parent.position;
        _bonus.Apply();
    }

    private void OnEnable()
    {
        SetEnableBonus(false);
    }

    public void SetEnableBonus(bool value)
    {
        _boxCollider2D.enabled = value;
        _spriteRenderer.enabled = value;
        _movingBonus.enabled = value;
    }
}
