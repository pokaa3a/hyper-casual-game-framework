using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace example
{
    public class Initializer : MonoBehaviour
    {
        void Start()
        {
            Register();

            Initialize();
        }

        void Register()
        {
            // State Transition
            Admin.instance.RegisterStateTransition(new StateTransition());

            // Level Loader
            Admin.instance.RegisterLevelLoader(new LevelLoader());
        }

        void Initialize()
        {
            UIManager.instance.uiPositions.HideAll();
            Admin.instance.state = GameState.Ready;
        }
    }
}
