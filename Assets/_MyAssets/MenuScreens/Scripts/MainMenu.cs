using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    // The Main menu script.
    // These functions are called by the buttons in the UI.

    public int firstLevelIndex = 1;                         // The index of the first level. (could be different if there are tutorials
    public Camera cam;
    public Transform pointA;
    public Transform pointB;
    public GameObject mainMenu;
    public GameObject Sources;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Cursor.visible = true;                              // Shows the cursor.
            Sources.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void PlayGame ()                                 // Called to play the game.
    {
        Scene scene = SceneManager.GetActiveScene();        // Gets the currently active scene.
        SceneManager.LoadScene(scene.buildIndex + 1);       // Loads the next scene in the index build.
    }

    public void Resart ()                                   // Called to restart the game.
    {
        SceneManager.LoadScene(firstLevelIndex);            // Loads the first level.
    }

    public void Source ()
    {
        mainMenu.SetActive(false);
        Sources.SetActive(true);
        cam.transform.position = pointB.position;
    }


    public void QuitGame ()                                 // Called to quit the game.
    {
        Application.Quit();                                 // Quits the game.
    }
}
