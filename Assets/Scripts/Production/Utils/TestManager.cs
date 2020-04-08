using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager: ManagerBase
{

    private void Awake()
    {
        
    }
    protected override void StateSwitch(object sender, GameState state)
    {
        base.StateSwitch(sender, state);
        switch (state)
        {
            case GameState.NewGame:
                break;
            case GameState.Restart:
                break;
            case GameState.NextLevel:
                break;
            default:
                break;
        }
    }
}
