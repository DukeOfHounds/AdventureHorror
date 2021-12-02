using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    GameObject pauseScreen;
    Player player;
    // public bool paused = false;
    void Awake()
    {
        pauseScreen = this.gameObject;
    }
    public void Restart()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reloads current Scene
        Time.timeScale = 1;

    }
    public void MainMenu()
    {

        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Destroy(this.gameObject);
    }
    public void PauseGame(GameObject p)
    {
        player = p.GetComponent<Player>(); ;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
