using System.Collections;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;

public class Tower : Tile
{
    public ObjectPool projectilePool;
    public bool test = false;
    public GameObject target = null;
    public float attackSpeed;
    [SerializeField]GameObject turret;

    public UnitManager unitManager;
    HashSet<GameObject> enemiesNerby = new HashSet<GameObject>();
    private void OnEnable()
    {      
        float rand = Random.Range(0.1f, 2);
        InvokeRepeating("Fire", rand, 1);
        InvokeRepeating("FindEnemies", rand, attackSpeed / 2);      
    }
   
   
    void Fire()
    {
        if (test)
        {
            Debug.Log(transform.localPosition);
            Debug.Log(gameObject.transform.position);
        }
        
        if (target)
        {
            Debug.Log("Fire");
            GameObject projectile = projectilePool.GetUnit(false);
            
            projectile.transform.position = turret.transform.position;
            projectile.transform.LookAt(target.transform);
            projectile.SetActive(true);

        }
        else
        {
            Debug.Log("FindEnemies");
            FindEnemies();
        }
        
    }
    void FindEnemies()
    {
        GameObject closestEnemy = null;
        Debug.Log(enemiesNerby.Count);
        if (enemiesNerby.Count >0)
        {
            foreach (GameObject unit in enemiesNerby)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = unit;
                }
                else
                {
                    if (Vector3.Distance(transform.position, unit.transform.position) < Vector3.Distance(transform.position, closestEnemy.transform.position))
                    {
                        closestEnemy = unit;
                    }
                }
            }

            if (closestEnemy != null)
            {
                closestEnemy.GetComponent<OnDisableEvent>().OnDisableObject += RemoveFromList;
            }
        }
       
        target = closestEnemy;
    }

    void RemoveFromList(GameObject unit)
    {
        if (enemiesNerby.Contains(unit))
        {
            enemiesNerby.Remove(unit);
            
        }
        if (unit == target)
        {
            target = null;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (enemiesNerby.Contains(other.gameObject))
        {
            enemiesNerby.Remove(other.gameObject);
        }
        if (other.gameObject == target)
        {
            target = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {         
            if (target = null)
            {
                target = other.gameObject;               
            }
            other.gameObject.GetComponent<OnDisableEvent>().OnDisableObject += RemoveFromList;
            enemiesNerby.Add(other.gameObject);
        }
    }

}
