using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Vector2 playerPosition;
    public Vector2 goalPosition;
    public List<Vector2> gravityCirclesPosition;
    // public List<Vector2> obstaclesPosition;

    public LevelData(Vector2 playerPos, Vector2 goalPos, List<Vector2> gravityCirclesPos) // , List<Vector2> obstaclesPos)
    {
        playerPosition = playerPos;
        goalPosition = goalPos;
        gravityCirclesPosition = gravityCirclesPos;
        // obstaclesPosition = obstaclesPos;
    }

    public static List<LevelData> GetDummyData()
    {
        List<LevelData> LD = new List<LevelData>();
       
        List<Vector2> gravityCirclesListLevel1 = new List<Vector2>();
        gravityCirclesListLevel1.Add(new Vector2(-2, 2));
        gravityCirclesListLevel1.Add(new Vector2(1, 2));
        LD.Add(new LevelData(new Vector2(0, 0), new Vector2(-1, -4), gravityCirclesListLevel1));

    List<Vector2> gravityCirclesListLevel2 = new List<Vector2>();
        gravityCirclesListLevel2.Add(new Vector2(0, 5));
        gravityCirclesListLevel2.Add(new Vector2(3, 4));
        gravityCirclesListLevel2.Add(new Vector2(-0, -5));
        LD.Add(new LevelData(new Vector2(1, 1), new Vector2(-1, -1), gravityCirclesListLevel2));

        return LD;
    }
}
