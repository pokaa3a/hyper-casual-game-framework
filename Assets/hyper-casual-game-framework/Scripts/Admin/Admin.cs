using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admin : MonoBehaviour
{
    public static Admin instance;

    private StateTransitionBase _stateTransition = new StateTransitionBase();
    private LevelManager _level = new LevelManager();

    public GameState state
    {
        get => _stateTransition.state;
        set { _stateTransition.state = value; }
    }

    public LevelManager level { get => _level; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void RegisterStateTransition(StateTransitionBase stateTransition)
    {
        GameState tmpState = state;
        _stateTransition = stateTransition;
        state = tmpState;
    }

    public void RegisterLevelLoader(LevelLoaderBase levelLoader)
    {
        _level.levelLoader = levelLoader;
    }
}
