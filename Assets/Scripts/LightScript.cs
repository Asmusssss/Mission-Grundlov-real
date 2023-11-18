using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class LightScript : MonoBehaviour
{

    [SerializeField] private LayerMask wall;
    [SerializeField] private GameObject cone;

    float defaultScale;
    float normalDistance;

    private void Start()
    {
        defaultScale = transform.localScale.z;
        Debug.Log(defaultScale);

        normalDistance = 7;// defaultScale * 2 * transform.parent.localScale.z;

        Debug.Log(normalDistance);

    }
    void Update()
    {

        Vector3 vectorToWall = transform.forward*normalDistance;
        Ray ray =  new Ray(transform.position, vectorToWall);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out  hitInfo, vectorToWall.magnitude))
        {

            //Debug.Log(hitInfo.point);
            //Debug.Log("Name: " + hitInfo.collider.name);
            float distanceToWall = (transform.position - hitInfo.point).magnitude; // Beregn vha. raycast hitinfo. M?ske: (transform.position - hitInfo.point).magnitude
            Debug.Log(distanceToWall);
            float newScale = defaultScale * distanceToWall / normalDistance;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newScale);
            //Debug.Log(newScale);
            

        } else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, defaultScale);
        }

        

    }
}
