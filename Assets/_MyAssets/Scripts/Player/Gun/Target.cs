using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour {
    
    [Tooltip("If the gameObject has it's health managed in another script, set this to be the same.")]
    public float targetHP = 10;
    
    public UnityEvent OnHit;
    public UnityEvent OnDeath;

    public void TargetTakeDamage (float damage)
    {
        targetHP -= damage;
        if (OnHit != null) { OnHit.Invoke(); }

        if (targetHP <= 0)
        {
            if (OnDeath != null) { OnDeath.Invoke(); }
        }
    }

    
}
