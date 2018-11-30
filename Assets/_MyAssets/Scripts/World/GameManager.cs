using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public int spawnersDestroyed = 0;
    public Text hudScore;
    public Text deathScore;

    private void Start()
    {
        Time.timeScale = 1; // Allows the game to run.
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor in place.
        Cursor.visible = false;

    }

    private void Update()
    {
        hudScore.text = "Spawners Destroyed: " + spawnersDestroyed;
        deathScore.text = spawnersDestroyed.ToString();
    }
}
