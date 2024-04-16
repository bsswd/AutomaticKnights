using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class AudioBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _backingTrack;
    [SerializeField] private AudioClip _kickTrack;

    [SerializeField] private AudioSource _mainAudioSource;
    [SerializeField] private AudioSource _additionalAudioSource; 

    [SerializeField] private Button _buttonMusic;

    private void Start()
    {
        _mainAudioSource.clip = _backingTrack;
        _mainAudioSource.Play();

        _additionalAudioSource.clip = _kickTrack;

        _buttonMusic.onClick.AddListener( () => _additionalAudioSource.PlayOneShot(_kickTrack));
    }
}
