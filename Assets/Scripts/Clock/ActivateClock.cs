using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]

public class ActivateClock : MonoBehaviour
{
    [Header("Objets")]
    [SerializeField] GameObject Laser;
    [SerializeField] GameObject UIClock;

    [Header("Variables")]
    [SerializeField] float Transition;

    [Header("Events")]
    [SerializeField] UnityEvent EventsEnter;
    [SerializeField] UnityEvent EventsExit;

    private void Start()
    {
        UIClock.GetComponent<Transform>().DOScaleY(0, 0);
        Laser.SetActive(false);
        UIClock.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWatch")
        {
            EventsEnter.Invoke();
            openUIClock();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.tag == "PlayerWatch")
            {
                EventsExit.Invoke();
                closeUIClock();
            }
        }
    }

    private void openUIClock()
    {
        Laser.SetActive(true);
        UIClock.SetActive(true);
        UIClock.GetComponent<Transform>().DOScaleY(1, Transition);
    }

    private void closeUIClock()
    {
        Laser.SetActive(false);
        UIClock.GetComponent<Transform>().DOScaleY(0, Transition);
        StartCoroutine(disaperUIClock());
    }

    IEnumerator disaperUIClock()
    {
        yield return new WaitForSeconds(Transition);
        UIClock.SetActive(false);
    }
}
