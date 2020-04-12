using System;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private int health;
    private int damage;
    private float walkSpeed;

    public int Health { get {return health;}  set { health = value; }}
    public int Damage { get { return damage; }  set { damage = value; } }
    public float WalkSpeed { get { return walkSpeed; }  set { walkSpeed = value; } }

    

    float alpha = 0;
    public UnitManager manager;
    UnitEffectHandler handler;
    public event Action<GameObject> onDeath;

    public Vector3 endGoal;
    public Vector3 startPos;
    public Vector3 endPos;
    private int i = 1;
 
    
 
    private void OnEnable()
    {
        startPos = manager.GetNewVector(0);
        endPos = manager.GetNewVector(1);
        transform.LookAt(endPos);
    }
   
   
    private void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.Lerp(startPos, endPos, alpha);
        alpha += Time.deltaTime * WalkSpeed;
        if (alpha >= 1)
        {
            alpha = 0;
            i++;
            UpdateVectors();
        }
    }
    void UpdateVectors()
    {
        Debug.Log(endPos + " : " + endGoal);
        if (endPos == endGoal)
        {
            manager.waveHandler.TakeDamage(damage);
            DeSpawn();
        }
        else
        {
            startPos = endPos;
            endPos = manager.GetNewVector(i);
            transform.LookAt(endPos);
        }
        
    }
    public void DeSpawn()
    {
        
        gameObject.SetActive(false);
        
    }
    private void OnDisable()
    {
        i = 1;
       
        manager.Reset -= DeSpawn;
    }
    public void ApplyDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            DeSpawn();
        }
    }
    
}
