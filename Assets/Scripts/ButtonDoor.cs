using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonDoor : MonoBehaviour
{
    

    [SerializeField]
    GameObject DoorToButton;
    GameObject Key;
   
    


 
    
    bool hasKey = false;

    void OnTriggerEnter(Collider collider)
    {
        if (Key)
        {
            hasKey = true;
            DoorToButton.transform.position += new Vector3(0, 4, 0);
        }

    }
}
