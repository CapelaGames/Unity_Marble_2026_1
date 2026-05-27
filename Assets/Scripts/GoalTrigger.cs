using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject winGame;

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // Now we know the object that triggered the OnTriggerEnter is the player

            winGame.SetActive(true); 
            Time.timeScale = 0;

        }
    }
}
