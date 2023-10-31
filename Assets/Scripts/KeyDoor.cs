using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    GameObject Keyy;
    GameObject ButtonDoor;

    bool hasKey = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!hasKey)
        {
            hasKey = true;
            Keyy.transform.position += new Vector3(0, -4, 0);
        }

    }
}