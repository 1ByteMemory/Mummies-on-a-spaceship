using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float detTimer = 3f;

    private bool firstHit = true;
    private bool explodeDamage = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombie" && firstHit)
        {
            anim.enabled = true;
            explodeDamage = true;
        }
        else
        {
            firstHit = false;
            StartCoroutine(WaitExplode());
        }
        if (explodeDamage && collision.transform.tag == "Zombie")
        {
            Destroy(collision.gameObject);
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }


    IEnumerator WaitExplode()
    {
        yield return new WaitForSeconds(detTimer);
        anim.enabled = true;
        explodeDamage = true;
    }
}
