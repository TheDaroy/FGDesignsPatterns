using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private UnitManager manager;
    public UnitManager Manager { get { return manager; } set { manager = value; } }
    [SerializeField] private float SpawnIntervals = 2;

    float timer;
    int enemyToSpawn;
    UnitType[] WaveToSpawn;
  public void SpawnWave(UnitType [] Wave)
    {
        WaveToSpawn = Wave;
        enemyToSpawn = 0;
        timer = SpawnIntervals;
       

    }
    private void Update()
    {
        if (enemyToSpawn < WaveToSpawn.Length)
        {   
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                
                for (int x = 0; x < manager.UnitSpawnList.Length; x++)
                {
                    
                    if (manager.UnitSpawnList[x].TypeToSpawn == WaveToSpawn[enemyToSpawn])
                    {
                        
                        GameObject spawnedObject = Instantiate(manager.UnitSpawnList[x].PreFab, manager.pathFinder.GetVector(0), Quaternion.identity);
                        Unit unit = spawnedObject.GetComponent<Unit>();
                        unit.manager = manager;

                        unit.Health = manager.UnitSpawnList[x].Health;
                        unit.Damage = manager.UnitSpawnList[x].Damage;
                        unit.WalkSpeed = manager.UnitSpawnList[x].WalkSpeed;
                        timer = SpawnIntervals;
                        enemyToSpawn++;
                        break;
                    }
                }
            }
        }
    }


}
