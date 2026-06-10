using TMPro;
using UnityEngine;

public class InputPlayerName : MonoBehaviour
{
    public SaveToFile saveToFile;
    public GameManager gameManager;

    public GameObject nameInputPanel;
    public TMP_InputField nameField;
    public TMP_Text currentHighScore;

    public void CheckHighScore()
    {
        float timeRemaining = gameManager.timer;
        SaveData saveData = saveToFile.GetHighScore();
        currentHighScore.text = $"Current High Score: {saveData.playerName} - {saveData.bestTime:F2} seconds";

        if (timeRemaining > saveData.bestTime)
        {
            nameInputPanel.SetActive(true);
        }
    }

    public void Submit()
    {
        float timeRemaining = gameManager.timer;
        string playerName = nameField.text.Trim();
        if (playerName == "")
        {
            playerName = "Player";
        }
        saveToFile.NewScore(timeRemaining, playerName);
        nameInputPanel.SetActive(false);
    }
}
