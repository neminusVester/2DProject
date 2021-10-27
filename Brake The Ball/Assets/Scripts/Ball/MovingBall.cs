using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private const float Force = 300f;
    private bool _isActive = false;

    private void OnEnable()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        MoveInput.OnPressed += ActivateBall;
    }

    private void OnDisable()
    {
        MoveInput.OnPressed -= ActivateBall;    
    }

    private void ActivateBall()
    {
        if (!_isActive)
        {
            transform.SetParent(null);
            _isActive = true;
            _rb.bodyType = RigidbodyType2D.Dynamic;
            AddForce();
        }
    }

    public void AddForce(float direction = 0f)
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(direction * (Force / 2), Force));
    }

    public void StartClone(float direction)
    {
        _isActive = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
        AddForce(direction);
    }
}


