using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    GameObject VaultDoor;

    bool isOpened = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!isOpened)
        {
            isOpened = true;
            VaultDoor.transform.position += new Vector3(0, 4, 0);
        }
        
    }
}
