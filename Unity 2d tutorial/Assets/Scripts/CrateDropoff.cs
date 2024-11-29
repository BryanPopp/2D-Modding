using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDropoff : MonoBehaviour
{
    public ParticleSystem supplyEffect;
    public AudioClip supplyClip;
    public bool isDelivered;

    void Start()
    {
        isDelivered = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "DropOffZone")
        {
            isDelivered = true;
            supplyEffect.Play();
        }
    }

}