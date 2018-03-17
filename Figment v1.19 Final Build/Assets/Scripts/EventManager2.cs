using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager2 : MonoBehaviour
{

    public PlayerHealthManager playerHealth;
    public Clown_EnemyHealthManager clownHealth;

    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    public GameObject dialogBox;
    private bool paused = false;

    public control e;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Game Over Panel
        if (playerHealth.currentHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
        if (clownHealth.currentHealth <= 0)
        {
            e.winCondition = true;
            Invoke("dialogDelay", 2);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("End_Credits");
            }
        }

        // Pausing Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        } else if (!paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        // Pause while dialog box is active
        if (dialogBox.activeSelf)
        {
            Time.timeScale = 0f;
        } else if (!dialogBox.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
    
    public void dialogDelay()
    {
        dialogBox.SetActive(true);
    }

    public void Resume()
    {
        paused = false;
    }

    public void RestartLevel(string levelName)
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(levelName);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}