using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{

    void Loadscene(string sceneName)
    {
    }
        void OnCollisionsEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }

       
        
    }

    

  
}
