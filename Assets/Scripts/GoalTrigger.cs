using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winGame;
    public InputPlayerName inputPlayerName;

    public GameManager gameManager;
    public SaveToFile saveToFile;

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Now we know the object that triggered the OnTriggerEnter is the player

            winGame.SetActive(true);

            inputPlayerName.CheckHighScore();
            Time.timeScale = 0;

        }
    }
}
