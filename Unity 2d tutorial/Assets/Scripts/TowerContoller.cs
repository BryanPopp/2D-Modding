using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

   Rigidbody2D rigidbody2d;
   Animator animator;
   int towerhealth;
   public AudioClip collectedClip;
   private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameObject playerControllerObject = GameObject.FindWithTag("RubyController");
         if (playerControllerObject != null)
        {
            playerController = playerControllerObject.GetComponent<PlayerController>();
            print ("Found the GameConroller Script!");
        }
        if (playerController == null)
        {
            print ("Cannot find GameController Script!");
        }
        towerhealth = 2;
    }

    void Update()
    {

    }

   void OnCollisionEnter2D(Collision2D other)
    {
      Debug.Log("EnemyCollider: " + other.gameObject.name);
      PlayerController player = other.gameObject.GetComponent<PlayerController>();
    }

   public void TowerHP(int HPamt)
   {
      towerhealth = towerhealth + HPamt;
      if (towerhealth <= 0)
      {
         Electrified();
      }
   }

    public void Electrified()
   {
       animator.SetTrigger("Electrified");
       if (playerController != null)
       {
         rigidbody2d.simulated = false;
         playerController.PlaySound(collectedClip);
         playerController.TowerTracker(1);
       }
   }

}
