﻿using System;
using System.Linq;
using UnityEngine;

namespace MemoryTool
{
    public class OnDisableEvent : MonoBehaviour
    {
        public event Action<GameObject> OnDisableObject;
       
        private void OnDisable()
        {
            OnDisableObject?.Invoke(this.gameObject);
        }
    }
}

