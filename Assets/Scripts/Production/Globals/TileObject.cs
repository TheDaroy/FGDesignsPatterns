using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Tiles/TileObject")]
public class TileObject : ScriptableObject
{
    [SerializeField] private TileType sign;
    [SerializeField] private GameObject tile;

    public TileType Sign { get => sign; }
    public GameObject Tile { get => tile; }

}
