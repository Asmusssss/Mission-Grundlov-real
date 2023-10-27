using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseScript : MonoBehaviour
{

    public float timeRemaining = 3;


    private SimpleController playerscript;

    public LayerMask mask;

    private void Update()
    {
        int col = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f,0.5f), Quaternion.identity, mask).Length;
        if (col > 0 )//&& playerscript.NoiseLevel == 2 )
        {
            SceneManager.LoadScene("loseScene");
            //if (timeRemaining > 3)
            {
                //timeRemaining -= Time.deltaTime;
                
            } 
            //else
            {
                //SceneManager.LoadScene("loseScene");
            }

        }
    }

}

