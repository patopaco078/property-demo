using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchPlayer : MonoBehaviour
{
    private bool CanWatch;

    [SerializeField] private Transform PlayerTransform;

    [SerializeField] Vector3 Direction = new Vector3(0, 0, 0);
    float A;
    float B;

    private void Update()
    {
        A = PlayerTransform.position.x - gameObject.transform.position.x;
        B = PlayerTransform.position.z - gameObject.transform.position.z;
        Direction.y = (Mathf.Asin(A * (1 / Mathf.Sqrt((A * A) * (B * B))))) * 180 / Mathf.PI;
        Debug.Log(Mathf.Sqrt((A * A) * (B * B)));
    }

    public void StartWatch()
    {
        CanWatch = true;
    }
}
