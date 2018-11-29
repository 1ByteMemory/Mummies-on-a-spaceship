using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject parent;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            parent.SetActive(false);
        }
    }

    void Start () {
        parent.SetActive(true);
	}
}
