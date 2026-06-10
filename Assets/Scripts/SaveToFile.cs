using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float bestTime = float.PositiveInfinity;
    public string playerName = "Player";
}


public class SaveToFile : MonoBehaviour
{
    SaveData saveData = new SaveData();
    string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "highscore.json");
        Load();
    }

    public bool NewScore(float timeRemaining, string name)
    {
        // Check if the new score is better than the current best time
        if (timeRemaining > saveData.bestTime)
        {
            // if it is, update the best time and player name
            saveData.bestTime = timeRemaining;
            saveData.playerName = name;
            SaveFile(); // Save the new high score to file
            return true;
        }
        return false;
    }

    void SaveFile()
    {
        string json = JsonUtility.ToJson(saveData); // Create Json String
        File.WriteAllText(filePath, json); // Write Json to file
    }

    void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // Read Json from file
            saveData = JsonUtility.FromJson<SaveData>(json); // Convert Json String to SaveData object
        }
    }

    public SaveData GetHighScore()
    {
        return saveData;
    }
}
