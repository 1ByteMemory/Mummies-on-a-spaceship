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
        // Explodes on impact if object has a target script and grenade hasn't already hit somthing.
        if (collision.transform.GetComponent<Target>() && firstHit)
        {
            Explode();
        }
        else
        {
            firstHit = false;
            StartCoroutine(WaitExplode());
        }
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.Euler(-90, 0, 0)); // Explosion affects.
        Destroy(gameObject);
    }


    IEnumerator WaitExplode()
    {
        // explodes after x amount of seconds.
        yield return new WaitForSeconds(detTimer);
        Explode();
    }
}
