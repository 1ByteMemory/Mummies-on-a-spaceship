using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Image hitIndicator;
    public Slider playerHealthSlider;

    private bool hit = false;
    private float startTime;
    private float endTime;
    private float t;
    private bool changing = false;

    public void PlayerHit ()
    {
        hit = true;
        playerHealthSlider.value = GetComponent<Target>().targetHP / 100;
    }

    public void PlayerDeath ()
    {
        Debug.Log("Blegh");
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
