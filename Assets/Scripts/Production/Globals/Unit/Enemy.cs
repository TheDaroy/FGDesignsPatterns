using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private int Damage;
    [SerializeField] private float Speed;

    private float nameThisLater = 0;
    public EnemyManager manager;

    public Vector3 startPos;
    public Vector3 endPos;
    private int i = 1;
    private void OnEnable()
    {
        startPos = manager.GetNewVector(0);
        endPos = manager.GetNewVector(1);
    }
    private void OnDisable()
    {
        i = 1;
    }
    private void Update()
    {
       Move();
    }
    void Move()
    {
        transform.position = Vector3.Lerp(startPos, endPos, nameThisLater);
        nameThisLater += Time.deltaTime * Speed;
        if (nameThisLater >= 1)
        {
            i++;
            UpdateVectors();
        }
    }
    void UpdateVectors()
    {
        endPos = startPos;
        startPos = manager.GetNewVector(i);
    }
    

}
