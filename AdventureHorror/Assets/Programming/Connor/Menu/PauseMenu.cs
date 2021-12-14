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
        player = FindObjectOfType<Player>();
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
       // player = p.GetComponent<Player>();
        player.paused = false ;
        Destroy(this.gameObject);
    }
    public void PauseGame(GameObject p)
    {
        player = p.GetComponent<Player>(); ;
        player.paused = true;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    #region Input Methods
    public void OnEscape(InputAction.CallbackContext context)
    {
        if (player.paused == true && context.canceled)
        {
            ResumeGame();
        }
    }
        #endregion
    }
