using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonDoor : MonoBehaviour
{
    

    [SerializeField]
    GameObject DoorToButton;
    GameObject Key;
   
    GameObject.Find("Key").transform.position;


    new Vector3 = (-13,-3,-3);
    
    bool hasKey = false;

    void OnTriggerEnter(Collider collider)
    {
        if (Key = Vector3)
        {
            hasKey = true;
            DoorToButton.transform.position += new Vector3(0, 4, 0);
        }

    }
}
