using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler 
{
    public UnitManager manager;
    int remainingEnemies;

    int health = 100;
    public void WaveSetup(UnitType[] Wave)
    {
        remainingEnemies = Wave.Length;
    }
   public void OnEnemyDespawn()
    {
        remainingEnemies -= 1;
        if (remainingEnemies <= 0)
        {
            manager.NextWave();
        }
    }
    public void TakeDamage(int damageTaken)
    {
        // Would probably connect a player class somewhere around here with a health variable, 
        // but will just put the health variable here since the player got nothing to do;
        health -= damageTaken;
        if (health <= 0)
        {
            manager.OnDeath();
        }

    }

}
