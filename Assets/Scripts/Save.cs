using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save instance;

    [System.Serializable]
    class SaveData
    {
        public float bestTime = 0f;
    }

    SaveData data = new SaveData();
    string filePath;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        filePath = Path.Combine(Application.persistentDataPath, "highscore.json");
        Load();
    }

    // Returns true if this is a new record
    public bool TrySetHighScore(float timeRemaining)
    {
        if (timeRemaining > data.bestTime)
        {
            data.bestTime = timeRemaining;
            SaveToFile();
            return true;
        }
        return false;
    }

    public float GetHighScore()
    {
        return data.bestTime;
    }

    void SaveToFile()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("High score saved: " + data.bestTime + "s to " + filePath);
    }

    void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("High score loaded: " + data.bestTime + "s");
        }
    }
}
