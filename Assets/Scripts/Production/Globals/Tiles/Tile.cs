using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
       
    public void DeSpawn(MapManager Mmanager)
    {
        Mmanager.Reset -= DeSpawn;
        gameObject.SetActive(false);
    }


}
