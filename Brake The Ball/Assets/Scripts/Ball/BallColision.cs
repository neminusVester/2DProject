using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColision : MonoBehaviour
{
    [SerializeField] private MovingBall _ball;
    [SerializeField] private BallSound _ballColloredSound;
    [SerializeField] private BallSound _ballImmortalSound;
    private float _lastPositionX;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out OtherBlock otherBlock))
        {
            _ballImmortalSound.PlaySoundImmortalCollision();
        }
        if (other.gameObject.TryGetComponent(out Block block) || other.gameObject.TryGetComponent(out MovingPaddle paddle))
        {
            _ballColloredSound.PlaySoundColloredCollision();
        }

        float ballPositionX = transform.position.x;

        if (other.gameObject.TryGetComponent(out MovingPaddle movingPaddle))
        {
            float collisionPointX = other.contacts[0].point.x;
            float paddleCenterPosition = movingPaddle.gameObject.transform.position.x;
            float difference = paddleCenterPosition - collisionPointX; // the difference between center paddle and point of collision
            float direction = collisionPointX < paddleCenterPosition ? -1 : 1;
            _ball.AddForce(direction * Mathf.Abs(difference));

        }
        _lastPositionX = ballPositionX;

        if (other.gameObject.TryGetComponent(out IDamage damage))
        {
            damage.TakeDamage();
        }
    }
}
