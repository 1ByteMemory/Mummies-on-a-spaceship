using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour {

    public float explosionDamage = 5;

    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!ps.isEmitting)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.transform.name);
        if (other.transform.GetComponent<Target>())
        {
            Debug.Log(other.transform.tag);
            other.transform.GetComponent<Target>().TargetTakeDamage(explosionDamage); // Object with target script takes damage.
        }
    }
}
