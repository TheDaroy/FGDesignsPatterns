using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostProjectile : Projectile
{
    float duration = 1;
    int effect = 5;

   

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("Hit Something");
            other.gameObject.GetComponent<UnitEffectHandler>().Freeze(duration, effect); // Look i am sorry ok! I am kind of running out of time and i couldn't get the react event thingy to work as i intended!
            gameObject.SetActive(false);
        }
    }


}
