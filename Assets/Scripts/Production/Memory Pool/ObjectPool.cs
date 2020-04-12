using System;
using System.Linq;
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
        private event Action unitReturned;
        public event Action UnitReturned
        {
            add
            {
                if (unitReturned == null || !unitReturned.GetInvocationList().Contains(value))
                {
                    unitReturned += value;
                }
            }
            remove
            {
                unitReturned -= value;
            }
        }

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
                GameObject instance = UnityEngine.Object.Instantiate(prefab, parent);
                OnDisableEvent disableEvent = instance.AddComponent<OnDisableEvent>();
                disableEvent.OnDisableObject += AddToStack;
               
                objectStack.Push(instance);
            }
        }
        
        private void AddToStack(GameObject gameObject)
        {
            unitReturned?.Invoke();
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

