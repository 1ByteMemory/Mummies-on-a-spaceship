using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Image hitIndicator;
    public Slider playerHealthSlider;
    public GameObject deathScreen;
    public GameObject HUD;

    private bool hit = false;
    private float startTime;
    private float endTime;
    private float t;
    private bool changing = false;

    private void Start()
    {
        deathScreen.SetActive(false);
        playerHealthSlider.value = 1;
    }

    public void PlayerHit ()
    {
        hit = true;
        playerHealthSlider.value = GetComponent<Target>().targetHP / 100;
    }

    public void PlayerDeath ()
    {
        HUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    private void Update()
    {
        if (hit)
        {
            if (!changing)
            {
                t = 0;
                changing = true;
            }
            else
            {
                hitIndicator.color = Color.Lerp(new Color(1, 0, 0, 0.5f), new Color(0, 0, 0, 0), t);
                t += Time.deltaTime;
                if (t >= 1) { changing = false; hit = false; }
            }
        }
        else
        {
            hitIndicator.color = new Color(0, 0, 0, 0);
        }
    }
}
