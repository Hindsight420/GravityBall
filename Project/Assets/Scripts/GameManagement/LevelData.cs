using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public List<ElementPosition> elementPositions = new List<ElementPosition>();

    public struct ElementPosition
    {
        public string element;
        public Vector2 position;
    }

    public LevelData()
    {

    }

    public LevelData(string jsonData)
    {
        elementPositions = JsonConvert.DeserializeObject<List<LevelData.ElementPosition>>(jsonData);
    }
}
