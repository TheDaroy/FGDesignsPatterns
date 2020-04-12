using UnityEngine;

public class UnitEffectHandler : MonoBehaviour
{
    // Look this script is just one giant mess, i had plans to do things differently but holy shit i am tired and i am running low on time.
    public Unit unit;

    private int baseHealth;
    private int baseDamage;
    private float baseWalkSpeed;


    bool freeseIsActive = false;
    float freezeDuration = 0;
    float freezeEffect = 0;
    private void Start()
    {
        baseHealth = unit.Health;
        baseDamage = unit.Damage;
        baseWalkSpeed = unit.WalkSpeed;
    }
    
    public void Freeze(float duration, int effect)
    {
        Debug.Log("Freeze");
        
        if (freezeDuration < duration)
        {
            freezeDuration = duration;   
        }
        if (freezeEffect < effect )
        {
            Debug.Log("Normal WalkSpeed :" + unit.WalkSpeed);
            Debug.Log(baseWalkSpeed);
            if (effect < 0)
            {
                unit.WalkSpeed = baseWalkSpeed / (effect * -1);
                
                freezeEffect = (effect * -1);
            }
            else
            {
                unit.WalkSpeed = baseWalkSpeed / effect;
                freezeEffect = effect;
            }
            Debug.Log("Freeze WalkSpeed :" + unit.WalkSpeed);
        }
        
    }

    private void Update()
    {
        if (freezeDuration > 0)
        {
            freezeDuration -= Time.deltaTime;
            if (freezeDuration <= 0)
            {
                FreezeReset();
            }
        }
    }
    private void FreezeReset()
    {
        unit.WalkSpeed = baseWalkSpeed;
        freezeDuration = 0;
        freezeEffect = 0;
    }
}

