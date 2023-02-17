using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class RandomizeAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Vector2 pitchRange;
    [SerializeField] private AudioClip[] _audioClips;
    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
        audioSource.Play();
    }
}

