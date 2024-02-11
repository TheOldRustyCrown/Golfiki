using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float shotForce=10;
    private bool isReadyForShot;
    private Vector3 delta;
    private void Awake()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody>();
        }
    }
    private void Update()
    {
        if (SwipeInput.ballRadiusReached)
        {
            isReadyForShot = true;
            delta = SwipeInput.deltaVector;
        }
        if (!SwipeInput.ballRadiusReached && isReadyForShot)
        {
            isReadyForShot = false;
            Shot();
        }
    }
    private void Shot()
    {
        rb.AddForce(new Vector3(delta.y*shotForce,0));
        Debug.Log("Shot");
    }
}
