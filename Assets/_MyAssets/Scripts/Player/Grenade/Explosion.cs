using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float detTimer = 3f;
    public ParticleSystem explosion;

    private bool firstHit = true;
    private bool explodeDamage = false;
    


    private void Start()
    {
        explosion.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombie" && firstHit)
        {
            Explode();
        }
        else
        {
            firstHit = false;
            StartCoroutine(WaitExplode());
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.Euler(-90, 0, 0));

        Destroy(gameObject);
    }


    IEnumerator WaitExplode()
    {
        yield return new WaitForSeconds(detTimer);
        Explode();
    }
}
