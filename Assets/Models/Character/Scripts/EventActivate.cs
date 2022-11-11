using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EventActivate :MonoBehaviour
{
    [SerializeField] AnimatorController controller;

    [HideInInspector] public bool IsUsing = false;
    
    [SerializeField] bool HaveBoxCollider;
    BoxCollider ActivateCollider;

    [Header("Audio")]
    [SerializeField] bool HaveAudio;  

    [Header("Animation")]
    [SerializeField] bool IsAnimated;
    [SerializeField] string NameTrigger;
    [SerializeField] Animator animator;

    [Header("Moving")]
    [SerializeField] bool IsMoving;
    [SerializeField] Transform WaypointToMove;
    [SerializeField] float TimeToMove;
    [SerializeField] public Transform Character;

    

    private void Start()
    {
        if (HaveBoxCollider)
        {
            ActivateCollider = GetComponent<BoxCollider>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartEvent();
            IsUsing = true;
        }
    }

    public void SetVariables(Transform ExternalTransform, Animator ExternalAnimator)
    {
        animator = ExternalAnimator;
        Character = ExternalTransform;
    }

    public void StartEvent()
    {
        if (IsAnimated)
            Animate();
        if (IsMoving)
            moveCharacter();
        if (HaveAudio)
            StartAudio();
        controller.NextEvent();
        ActivateCollider.enabled = false;
    }

    private void moveCharacter()
    {
        Character.DOMove(WaypointToMove.position, TimeToMove);
    }

    private void Animate()
    {
        animator.SetTrigger(NameTrigger);
    }

    private void StartAudio()
    {
        controller.StarAudio();
    }
}
