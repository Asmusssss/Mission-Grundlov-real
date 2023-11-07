using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen: MonoBehaviour
{
    [SerializeField]
    GameObject VaultDoor;

    bool isOpened = false;

    void OnTriggerEnter(Collider col)
    {
        if (!isOpened)
        {
            isOpened = true;

            VaultDoor.transform.position += new Vector3(0, 4, 0);

        }

    }
}
