using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour, IDamage
{

    private static int _blockCount = 0;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private int _score;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _life;
    public static event Action OnEnded;
    public static event Action<int> OnDestroyed;
    public static event Action<Vector2> OnDestroyedPosition;

#if UNITY_EDITOR
    public BlockData BlockData;
#endif
    
    public void SetData(ColoredBlock blockData)
    {
        _sprites = new List<Sprite>(blockData.Sprites);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = blockData.BlocksColor;
        _score = blockData.Score;
        _life =  _sprites.Count;
        _spriteRenderer.sprite = _sprites[_life - 1];
        MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = _spriteRenderer.color;
    }

    public void TakeDamage()
    {
        _life--;
        if(_life < 1)
        {
            _spriteRenderer.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            OnDestroyedPosition?.Invoke(transform.position);
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            _spriteRenderer.sprite = _sprites[_life - 1];
        }
    }

    private void OnEnable() 
    {
       _blockCount++; 
    }

    private void OnDisable() 
    {
        _blockCount--;
        OnDestroyed?.Invoke(_score);

        if(_blockCount < 1)
        {
            OnEnded?.Invoke();
        }
    }
}
