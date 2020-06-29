using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Missile : GamePlayElement
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
        targetOfMissile = searchForPlayerTag[0].transform;                      //Zoekt de transform van eerste object met Player tag.


        Vector3 distanceFromTarget = targetOfMissile.position - transform.position;  //Rekent het verschil uit tussen de twee posities.
        Vector3 directionToTarget = distanceFromTarget.normalized;                   //Rekent de richting uit op basis van het verschil tussen de twee posities naar coords 0,0
        Vector3 velocity = directionToTarget * missileSpeed;
        Vector3 moveAmount = velocity * Time.deltaTime;

        float directionAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;  // Richting
        directionAngle -= 90;
        transform.rotation = Quaternion.AngleAxis(directionAngle, Vector3.forward);
              

        transform.position = transform.position + moveAmount;
    }
}
