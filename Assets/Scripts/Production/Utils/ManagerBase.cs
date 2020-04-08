using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerBase: MonoBehaviour
{
   
   [SerializeField] protected GameManager mainManager;

    protected virtual void OnEnable()
    {
        mainManager.state += StateSwitch;
    }
    protected virtual void OnDisable()
    {
        mainManager.state -= StateSwitch;
    }

    protected virtual void StateSwitch(object sender, GameState state)
    {
        
    }

    

}
