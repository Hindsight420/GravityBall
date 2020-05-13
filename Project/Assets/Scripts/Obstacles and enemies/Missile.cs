using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform targetOfMissile;
    public float missileSpeed = 3f;
    GameObject[] searchForPlayerTag;

    private void Awake()
    {
         
    }
    void Update()
    {
        searchForPlayerTag = GameObject.FindGameObjectsWithTag("Player");
        if (searchForPlayerTag.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'Player'");
        }

        targetOfMissile = searchForPlayerTag[0].transform;                      //Zoekt de transform van eerste object met Player tag.


        Vector3 distanceFromTarget = targetOfMissile.position - transform.position;  //Rekent het verschil uit tussen de twee posities.
        Vector3 directionToTarget = distanceFromTarget.normalized;                   //Rekent de richting uit op basis van het verschil tussen de twee posities naar coords 0,0
        Vector3 velocity = directionToTarget * missileSpeed;                        
        Vector3 moveAmount = velocity * Time.deltaTime;

        transform.position += moveAmount;


    }
}
