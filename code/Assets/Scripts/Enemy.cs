using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
   /// <summary>
   /// OnCollisionEnter is called when this collider/rigidbody has begun
   /// touching another rigidbody/collider.
   /// </summary>
   /// <param name="other">The Collision data associated with this collision.</param>
    void OnParticleCollision(GameObject other) 
   {
       Destroy(gameObject);
   }
}
