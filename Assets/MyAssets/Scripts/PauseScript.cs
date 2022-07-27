using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject PauseMenuUi;
    public GameObject Player;
    public GameObject Camera;
    public GameObject GUI;


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (Paused)
            {
                Resume();
            }
          else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Player.SetActive(true);
        Camera.SetActive(true);
        GUI.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Player.SetActive(false);
        Camera.SetActive(false);
        GUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
