using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    public List<GameObject>[] pool;
    public ObjectPool(int i)
    {
        pool = new List<GameObject>[i];
    }


}
