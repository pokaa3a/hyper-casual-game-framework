using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,       // Empty state to indicate the state transition is not ready.
    Ready,      // Game scene is ready, waiting for user input.
    GamePlay,   // While the user is playing.
    Completed,  // After user passes the level.
    Failed      // After user failed the lavel.
};

public class StateTransitionBase
{
    protected GameState _state = GameState.None;
    public GameState state
    {
        get => _state;
        set
        {
            if (_state != value && value != GameState.None) // should never change to None state!
            {
                if (value == GameState.Ready)
                {
                    EnterReadyState();
                }
                else if (value == GameState.GamePlay)
                {
                    EnterGamePlayState();
                }
                else if (value == GameState.Completed)
                {
                    EnterCompletedState();
                }
                else if (value == GameState.Failed)
                {
                    EnterFailedState();
                }
                _state = value;
            }
        }
    }

    protected virtual void EnterReadyState() { }

    protected virtual void EnterGamePlayState() { }

    protected virtual void EnterCompletedState() { }

    protected virtual void EnterFailedState() { }
}
