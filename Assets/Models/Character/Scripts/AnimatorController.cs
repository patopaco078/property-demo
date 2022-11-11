using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimatorController : MonoBehaviour
{
    [SerializeField] EventActivate[] EventActivates;
    [SerializeField] List<AudioClip> AudioClips;
    private int ActualEvent = 0;
    [SerializeField] private int ActualAudio = 0;
    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void NextEvent()
    {
        ActualEvent++;
    }

    public void StarAudio()
    {
        AudioSource.clip = AudioClips[ActualAudio];
        AudioSource.Play();
        ActualAudio++;
    }
}
