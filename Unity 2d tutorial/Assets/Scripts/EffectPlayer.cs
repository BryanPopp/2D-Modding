using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    public ParticleSystem healthEffect;
    public ParticleSystem damageEffect;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "HealthCollectable")
        {
            healthEffect.Play();
        }

        if (other.tag == "Damage")
        {
            damageEffect.Play();
        }
    }






}
