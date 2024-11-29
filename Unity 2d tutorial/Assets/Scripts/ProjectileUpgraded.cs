using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileUpgraded : MonoBehaviour


{
    Rigidbody2D rigidbody2d;
    

    void Awake()
    {
      rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
      if(transform.position.magnitude > 100.0f)
       {
           Destroy(gameObject);
       }

    }

    public void Launch(Vector2 direction, float force)
    {
      rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      EnemyController enemy = other.collider.GetComponent<EnemyController>();
      if (enemy != null)
      {
        enemy.Fix();
      }
      Destroy(gameObject);

    }
  
  //public void Upgraded()
  //{
   // transform.localScale += new Vector3(1.5f,1.5f,0);
  //}

}
