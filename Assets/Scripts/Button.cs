using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    [SerializeField] private float pressDownSpeed = 0.01f;
    [Tooltip("Action to take when button is pressed")]
    
    public GameObject VaultDoor;

    private Vector3 nextPosition;
    private Vector3 targetPosition;

    private bool ready = true;

    private void Start()
    {
        targetPosition = transform.localPosition;
        nextPosition = targetPosition;
        nextPosition.y -= 0.04f;
    }


    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                                                      targetPosition,
                                                      pressDownSpeed * Time.deltaTime);
    }

    public void OnHit()
    { 
        if (ready)
        {
            ready = false;
            (nextPosition, targetPosition) = (targetPosition, nextPosition);
        }
    }

    public void Release()
    {
        (nextPosition, targetPosition) = (targetPosition, nextPosition);
        ready = true;
    }
}