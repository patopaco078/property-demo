using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]

public class ActivateClock : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsActived;

    [Header("Events")]
    [SerializeField] UnityEvent EventsEnter;
    [SerializeField] UnityEvent EventsExit;

    private void Start()
    {
        for (int i = 0; i < gameObjectsActived.Length; i++)
        {
            gameObjectsActived[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWatch")
        {
            EventsEnter.Invoke();
            for (int i = 0; i < gameObjectsActived.Length; i++)
            {
                gameObjectsActived[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.tag == "PlayerWatch")
            {
                EventsExit.Invoke();
                for (int i = 0; i < gameObjectsActived.Length; i++)
                {
                    gameObjectsActived[i].SetActive(false);
                }
            }
        }
    }
}
