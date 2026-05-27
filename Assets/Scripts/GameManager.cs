using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lifeText; //----------
    public GameObject pauseMenu;
    public GameObject gameOver;

    public float timer = 0;
    public float lives = 3;

    public PlayerController player; //---------
    float startTimer;
    Vector3 startPosition; //------------

    void Start()
    {
        Time.timeScale = 1;
        lifeText.text = lives.ToString();

        startTimer = timer;
        startPosition = player.transform.position;
    }

    public void LoseLife() 
    {
        lives--; 
        lifeText.text = lives.ToString(); 

        if (lives <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            player.transform.position = startPosition;
            player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            timer = startTimer;
        }
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) // programs pause for esc button on keyboard
        {

            if(Time.timeScale == 0) 

            {

                pauseMenu.SetActive(false);  // if escape has not been pressed, leave it running at 1
                Time.timeScale = 1;  // turn timer back on

            }

            else

            {
                pauseMenu.SetActive(true); // if escape has been pressed, pause timer
                Time.timeScale = 0; // turn off timer
             
            }


        }

        if (timer <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        UpdateTimer();
    }

    void UpdateTimer()

    {

        timer -= Time.deltaTime;
        timerText.text = "TIMER: " + timer.ToString("F0"); // F0, F1, F2 is how many decimal places

    }

    public void Reload()  // Allow the player to reload the current scene

    {

        Scene currentScene = SceneManager.GetActiveScene();  // Telling scene manager the current scene is one open
        SceneManager.LoadScene(currentScene.buildIndex);  // Loading the current scene (resetting the scene)

    }

    public void Quit() // Quitting the game (does not work in Unity editor)


    {
        Application.Quit(); // Telling Unity to close the game

    }

    public void Menu() // Take us back to main menu

    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Unity will look for a scene called MainMenu then open it
    
    }

}
