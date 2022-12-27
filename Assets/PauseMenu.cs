using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    // public GameObject HUD;
    public GameObject player;
    


    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                
                PauseGame();
                Cursor.lockState = CursorLockMode.None;

                //HUD.SetActive(false);
                player.GetComponent<ShooterManager>().enabled = false;
            }
            else if (isPaused)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;

                player.GetComponent<ShooterManager>().enabled = true;
                
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        player.GetComponent<ShooterManager>().enabled = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        player.GetComponent<ShooterManager>().enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
       
    }

    public void RestartLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
        ResumeGame();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("UI scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
