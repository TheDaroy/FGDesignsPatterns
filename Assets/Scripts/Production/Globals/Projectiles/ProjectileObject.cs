using System.Collections;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Projectile/ProjectileObject")]
public class ProjectileObject : ScriptableObject
{
    [SerializeField] private ProjectileType type;
    [SerializeField] private GameObject prefab;

    public ProjectileType Type { get => type; }
    public GameObject Prefab { get => prefab; }

    [Header("Pool Settings")]
    [SerializeField] public uint objectstoadd = 1;
    public uint Objectstoadd { get => objectstoadd; }
    public ObjectPool pool;

    public void InitiatePool(Transform parent = null)
    {
        pool = new ObjectPool(prefab, parent, objectstoadd);
    }
}
