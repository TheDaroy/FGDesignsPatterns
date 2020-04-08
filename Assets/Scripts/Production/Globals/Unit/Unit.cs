using System.Collections;
using System.Collections.Generic;
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

    public Vector3 startPos;
    public Vector3 endPos;
    private int i = 1;
 
    void OnSpawn()
    {
        startPos = manager.GetNewVector(0);
        endPos = manager.GetNewVector(1);
    }
    void OnDespawn()
    {
        i = 1;
    }
    private void Start()
    {
        OnSpawn();
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
        startPos = endPos;
        endPos = manager.GetNewVector(i);
    }

}
