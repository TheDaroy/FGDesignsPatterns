using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/UnitObject")]
public class UnitObject : ScriptableObject
{
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


}
