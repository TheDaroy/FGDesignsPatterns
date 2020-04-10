using System.Collections;
using System.Collections.Generic;
using MemoryTool;
using UnityEngine;
[CreateAssetMenu(menuName = "Objects/Units/UnitObject")]
public class UnitObject : ScriptableObject 
{
    [Header("Object Settings")]
    [SerializeField] private GameObject preFab;
    [SerializeField] private UnitType typeToSpawn;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float walkSpeed;

    public GameObject PreFab { get => preFab; }
    public UnitType TypeToSpawn { get => typeToSpawn; }
    public int Health { get => health; }
    public int Damage { get => damage; }
    public float WalkSpeed { get => walkSpeed; }

    [Header("Pool Settings")]
    [SerializeField] public uint objectstoadd = 1;
    public uint Objectstoadd { get => objectstoadd; }
    public ObjectPool pool;

    public void InitiatePool(Transform parent = null)
    {
        pool = new ObjectPool(preFab, parent, objectstoadd);
    }

}
