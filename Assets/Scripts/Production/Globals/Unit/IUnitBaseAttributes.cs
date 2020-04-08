using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IUnitBaseAttributes
    {
          [SerializeField] int health { get; }
          [SerializeField] int damage { get; }
          [SerializeField] float walkSpeed { get; }


       

    }
