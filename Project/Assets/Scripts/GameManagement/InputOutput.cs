using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class InputOutput
{
    public static string LevelDirectory
    {
        get
        {
            return Application.persistentDataPath;
        }
    }

    public static string GetLevelPath(int levelIndex)
    {
        return LevelDirectory + "/level" + levelIndex + ".json";
    }

    public static int FindHighestLevelFileNumber()
    {
        DirectoryInfo levelDirectory = new DirectoryInfo(LevelDirectory);
        FileInfo[] fileInfos = levelDirectory.GetFiles();
        List<int> fileNumbers = new List<int>();
        int highestFileNumber = 0;

        foreach (FileInfo fileInfo in fileInfos)
        {
            string fileName = fileInfo.Name;
            char[] charsToTrim = { 'l', 'e', 'v', '.', 'j', 's', 'o', 'n' };
            int fileNumber = System.Convert.ToInt32(fileName.Trim(charsToTrim));
            fileNumbers.Add(fileNumber);
        }

        if (fileNumbers.Count != 0)
        {
            highestFileNumber = fileNumbers.Max();
        }
        return highestFileNumber;
    }

    public static void SaveJsonDataToPath(string jsonData, string path)
    {
        File.WriteAllText(path, jsonData);
    }

    public static string LoadJsonDataFromPath(string path)
    {
        return File.ReadAllText(path);
    }
}
