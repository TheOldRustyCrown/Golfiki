using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    private Transform target;
    
    private void Update()
    {
        if (target)
        {
            transform.position = new Vector3(target.transform.position.x,this.transform.position.y,target.position.z);
        }
        CheckInput();
    }
    public void SetTarget(Transform t)
    {
        target = t;
    }
    private void CheckInput()
    {
        if (SwipeInput.ballRadiusReached)
        {
            return;
        }
        if (SwipeInput.swipedRightSide && SwipeInput.swipedDown)
        {
            RollRight();
        }
        if (SwipeInput.swipedRightSide && SwipeInput.swipedUp)
        {
            RollLeft();
        }
        if (SwipeInput.swipedLeftSide && SwipeInput.swipedUp)
        {
            RollRight();
        }
        if (SwipeInput.swipedLeftSide && SwipeInput.swipedDown)
        {
            RollLeft();
        }
    }
    private void RollRight()
    {
        transform.Rotate(-Vector3.up);
    }
    private void RollLeft()
    {
        transform.Rotate(Vector3.up);
    }
}
