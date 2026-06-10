using TMPro;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{
    public SaveToFile saveToFile;
    public GameManager gameManager;

    public TMP_Text currentHighScore;

    public void CheckHighScore()
    {
        float timeRemaining = gameManager.timer;
        SaveData saveData = saveToFile.GetHighScore();
        currentHighScore.text = $"Current High Score: {saveData.playerName} - {saveData.bestTime:F2} seconds";

        if (timeRemaining > saveData.bestTime)
        {
            saveToFile.NewScore(timeRemaining, "No name");
            currentHighScore.text += "\n" + "New HighScore! " + timeRemaining.ToString("F2") + " seconds";
        }
    }
}
