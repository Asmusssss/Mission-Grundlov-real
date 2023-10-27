using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{

    private void Update()
    {
        int col = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f)).Length;
        if(col > 0)
        {
            SceneManager.LoadScene("winScene"); 
        }
    }



}
