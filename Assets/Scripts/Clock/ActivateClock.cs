using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class ActivateClock : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsActived;

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
            for(int i = 0; i < gameObjectsActived.Length; i++)
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
                for (int i = 0; i < gameObjectsActived.Length; i++)
                {
                    gameObjectsActived[i].SetActive(false);
                }
            }
        }
    }
}
