using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour


{
    public CrateDropoff crateDropoff;
    Rigidbody2D rigidbody2d;

    void Awake()
    {
      crateDropoff = GameObject.Find("Supply Crate").GetComponent<CrateDropoff>();
      rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
            
      if(transform.position.magnitude > 100.0f)
       {
           Destroy(gameObject);
       }

    }

    void FixedUpdate()
    {
      if (crateDropoff != null)
      {
        Upgraded();
      }

    }

    public void Launch(Vector2 direction, float force)
    {
      rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      EnemyController enemy = other.collider.GetComponent<EnemyController>();
      TowerController tower = other.collider.GetComponent<TowerController>();
      PlayerController player = other.collider.GetComponent<PlayerController>();
      if (enemy != null)
      {
        enemy.Fix();
      }
      if (tower != null)
      {
        tower.TowerHP(-1);
      }
      Destroy(gameObject);

    }


  public void Upgraded()
  {
    if (crateDropoff.isDelivered)
    {
      transform.localScale += new Vector3(0.05f,0.05f,0);
    }
  }

  //public void DoIt()
 // {
   // if (crateDropoff.isDelivered)
   // {
   //   Debug.Log("Hi!!!!");
   // }
  //}

}
