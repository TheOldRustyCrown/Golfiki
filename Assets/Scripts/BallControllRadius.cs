using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllRadius : MonoBehaviour
{
    public Transform targetTransform;
    private void Update()
    {
        this.transform.position = targetTransform.position;
    }
}
