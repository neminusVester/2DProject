using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Space]
    [SerializeField] private AudioClip _colloredCollision;
    [SerializeField] private AudioClip _immortalCollision;

    public void PlaySoundColloredCollision()
    {
        if (AudioController.Audio.GetSoundValue())
        {
            _audioSource.PlayOneShot(_colloredCollision);
        }
    }

    public void PlaySoundImmortalCollision()
    {
        if (AudioController.Audio.GetSoundValue())
        {
            _audioSource.PlayOneShot(_immortalCollision);
        }
    }
}
