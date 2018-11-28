using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //The Pause Menu UI

    public static bool IsPaused = false;                      // Boolean to say if the game has been paused.
    public GameObject PauseMenuUI;                            // Reference to the Pause Menu UI
    
    private void Start()                                      // The start of the scene.
    {
        PauseMenuUI.SetActive(false);                         // The puase menu is deactivated.
        Cursor.visible = false;                               // Hides the cursor.
        Cursor.lockState = CursorLockMode.Locked;
    }
                
    void Update () {                                          // Every update of the game.
		if (Input.GetKeyDown(KeyCode.Escape)) {               // If escape is pressed:
            if (IsPaused)                                     // If the game has been paused 
            {
                Resume();                                     // Then it resumes the game.

            } else                                            // If the game isn't puased:
            {
                Pause();                                      // Puases the game.
            }
        }
	}
     
    public void Resume ()                                     // Function to resume the game.
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);                         // Deactivates the puase menu
        Time.timeScale = 1f;                                  // Game speed is set to normal gam espeed.
        IsPaused = false;                                     // the game is not puased.
        Cursor.visible = false;                               // Hides the cursor.
    }
     
    public void Pause ()                                      // Function that puases the game.
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);                          // Puse menu is activated.
        Time.timeScale = 0f;                                  // Time is stopped.
        IsPaused = true;                                      // The game is puased
        Cursor.visible = true;                               // Shows the cursor.
    }

    public void MainMenu ()                                   // Main menu function. Called by the buttons in the ui.
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);                            // Loads the main menu.
    }
}
