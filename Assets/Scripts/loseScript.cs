using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseScript : MonoBehaviour
{

    public float timeRemaining = 1.2f;


    private SimpleController playerscript;

    public LayerMask mask;

    private void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 1.5f, mask);
        if (col.Length > 0)
        {

            Collider player = col[0];
            playerscript = player.gameObject.GetComponent<SimpleController>();
            if(playerscript.NoiseLevel >= 2)
            {
                Debug.Log("ngfjyfjygf");
               
                if (timeRemaining > 0)
                {
                    Debug.Log(timeRemaining);
                    timeRemaining -= Time.deltaTime;

                }
                else
                {
                    
                    SceneManager.LoadScene("loseScene");
                }
            }
            

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}

