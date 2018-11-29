using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public int spawnersDestroyed = 0;
    public Text hudScore;
    public Text deathScore;

    private void Update()
    {
        hudScore.text = "Spawners Destroyed: " + spawnersDestroyed;
        deathScore.text = spawnersDestroyed.ToString();
    }
}
