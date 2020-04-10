using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace MemoryTool
{
    public class ObjectPool : IPool<GameObject>
    {
        Transform parent;
        GameObject prefab;
        uint objectsToAdd;
        readonly Stack<GameObject> objectStack = new Stack<GameObject>();
        public ObjectPool(GameObject _prefab, Transform _parent = null, uint _objectsToAdd = 1)
        {
            
            prefab = _prefab;
            parent = _parent;
            objectsToAdd = _objectsToAdd;
        }
        private void AddObject()
        {
            for (int i = 0; i < objectsToAdd; i++)
            {
                GameObject instance = Object.Instantiate(prefab, parent);
                OnDisableEvent disableEvent = instance.AddComponent<OnDisableEvent>();
                disableEvent.OnDisableObject += AddToStack;
               
                objectStack.Push(instance);
            }
        }
        
        private void AddToStack(GameObject gameObject)
        {
            objectStack.Push(gameObject);
        }
        public GameObject GetUnit(bool returnActive)
        {            
            if (objectStack.Count == 0)
            {
                AddObject();
            }
            GameObject instance = objectStack.Pop();
            instance.SetActive(returnActive);
            return instance;
        }

        

    }
}

