using System.Collections;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;
[CreateAssetMenu(menuName = "Objects/Tiles/TowerObject")]
public class TowerObject : ScriptableObject
{
    [SerializeField] private ProjectileObject projectile;
    [SerializeField] private float attackSpeed;

    public ProjectileObject Projectile { get => projectile; }
    public float AttackSpeed { get => attackSpeed; }


    [Header("Pool Settings")]
    [SerializeField] public uint objectstoadd = 1;
    public uint Objectstoadd { get => objectstoadd; }
    public ObjectPool pool;

    

}
