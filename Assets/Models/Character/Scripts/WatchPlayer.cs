using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchPlayer : MonoBehaviour
{
    private bool CanWatch;

    [SerializeField] private Transform PlayerTransform;

    Vector3 Rotation = new Vector3(0, 0, 0);
    private Vector3 distance = new Vector3(0, 0, 0);

    private void Update()
    {
        distance = PlayerTransform.position - transform.position;
        RotationBird();
    }

    public void StartWatch()
    {
        CanWatch = true;
    }

    public void RotationBird()
    {
        float directionInX;
        float Operation = Mathf.Acos((distance.x * distance.x) / (Mathf.Sqrt(distance.x * distance.x) * Mathf.Sqrt((distance.x * distance.x) + (distance.z * distance.z)))) * 180 / Mathf.PI;
        if (distance.x < 0)
        {
            directionInX = -1;
        }
        else
        {
            directionInX = 1;
        }

        if (distance.z > 0)
        {
            Rotation.y = (directionInX * (90 - Operation)) + 90;
        }
        else
        {
            Rotation.y = (directionInX * (90 + Operation)) + 90;
        }

        //Up Down
        /*
        float directionInY;
        float OperationY = Mathf.Acos((distance.y * distance.y) / (Mathf.Sqrt(distance.y * distance.y) * Mathf.Sqrt((distance.y * distance.y) + (distance.z * distance.z)))) * 180 / Mathf.PI;
        if (distance.y < 0)
        {
            directionInY = -1;
        }
        else
        {
            directionInY = 1;
        }

        if (distance.z > 0)
        {
            Rotation.x = directionInY * (90 - OperationY) * -1;
        }
        else
        {
            Rotation.x = directionInY * (90 + OperationY);
        }
        */
        transform.rotation = Quaternion.Euler(Rotation);
        
    }
}
