using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private AudioButton _sound;
    [SerializeField] private AudioButton _music;

    private void OnEnable()
    {
        _sound.SetState(AudioController.Audio.GetSoundValue());
        _music.SetState(AudioController.Audio.GetMusicValue());
    }

    public void ChangeSound()
    {
        AudioController.Audio.ChangeSound();
    }

    public void ChangeMusic()
    {
        AudioController.Audio.ChangeMusic();
    }
}
