using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    int damage = 2;
    float explosiveRadius = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("Explosive Hit Something");
            Collider[] hits = Physics.OverlapSphere(transform.position, explosiveRadius);
            Debug.Log("Explosive Hits :" + hits.Length);
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].gameObject);
                if (hits[i].gameObject.layer == 9)
                {
                    Debug.Log(hits[i].gameObject);
                    hits[i].gameObject.GetComponent<Unit>().ApplyDamage(2); // God i am so sorry.
                    
                }
               

            }
            gameObject.SetActive(false);
        }
    }
}
