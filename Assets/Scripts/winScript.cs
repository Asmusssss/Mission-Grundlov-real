using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    public LayerMask mask;

    private void Update()
    {
        int col = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f), Quaternion.identity, mask).Length;
        if(col > 0)
        {
            SceneManager.LoadScene("winScene1"); 
        }
    }



}
