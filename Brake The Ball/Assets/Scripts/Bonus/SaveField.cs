using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveField : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    
    public void SetActive(bool value)
    {
        _spriteRenderer.enabled = value;
        _boxCollider2D.enabled = value;
    }
}
