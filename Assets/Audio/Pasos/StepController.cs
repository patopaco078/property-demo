using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class StepController : MonoBehaviour
{
    [SerializeField] Step[] Steps;
    AudioSource _audioSource;
    private bool _isPlaying = false;
    private int _stepCount = 0;
    [SerializeField] float TimerToStopAudio = 0.3f;
    private float timerStep = 0;
    private bool SongActive;
    private bool a = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(timerStep > 0)
        {
            SongActive = true;
            timerStep -= Time.deltaTime;
        }
        else
        {
            _audioSource.Stop();
            SongActive = false;
            a = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < Steps.Length; i++)
        {
            if (Steps[i].Name == other.tag)
            {
                _isPlaying = true;
                _stepCount = i;
            }
        }
        if (_isPlaying)
        {
            _audioSource.clip = Steps[_stepCount].AudioStep;
            _audioSource.Play();
        }
    }

    public void Moving()
    {
        timerStep = TimerToStopAudio;
        if (a)
        {
            _audioSource.Play();
            a = false;
        }
    }
}
