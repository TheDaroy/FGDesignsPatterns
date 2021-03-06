﻿using System.Collections.Generic;

public static class TileMethods
{
    public static IReadOnlyDictionary<int, TileType> TypeById { get; } = new Dictionary<int, TileType>
    {
        { 0,  TileType.Path },
        { 1,  TileType.Obstacle },
        { 2,  TileType.TowerOne },
        { 3,  TileType.TowerTwo},
        { 8,  TileType.Start },
        { 9,  TileType.End },
    };

    public static IReadOnlyDictionary<TileType, ProjectileType> ProjectileByTower { get; } = new Dictionary<TileType, ProjectileType>
    {
        {TileType.TowerOne, ProjectileType.Explosive},
        {TileType.TowerTwo, ProjectileType.Frost}
    };
    public static bool IsWalkable(TileType type)
    {
        return type == TileType.Path || type == TileType.Start || type == TileType.End;
    }

    public static bool IsTower(TileType type)
    {
        return type == TileType.TowerOne || type == TileType.TowerTwo;
    }

   

    
    //public static TileType GetType(char sign)
    //{
    //    if (sign != ' ')
    //    {

    //    }
    //    return
    //}
}
