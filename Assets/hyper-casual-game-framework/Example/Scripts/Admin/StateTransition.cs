using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace example
{
    public class StateTransition : StateTransitionBase
    {
        protected override void EnterReadyState()
        {
            UIManager.instance.uiPositions.Move("ReadyFrame", UIVisibility.Show);
            UIManager.instance.uiPositions.Move("GamePlayFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("CompletedFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("FailedFrame", UIVisibility.Hide);

            Admin.instance.level.LoadLevel();
            UIManager.instance.UpdateLevelUI();
            GamePlay.instance.Reset();
        }

        protected override void EnterGamePlayState()
        {
            UIManager.instance.uiPositions.Move("ReadyFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("GamePlayFrame", UIVisibility.Show);
            UIManager.instance.uiPositions.Move("CompletedFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("FailedFrame", UIVisibility.Hide);
        }

        protected override void EnterCompletedState()
        {
            UIManager.instance.uiPositions.Move("ReadyFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("GamePlayFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("CompletedFrame", UIVisibility.Show);
            UIManager.instance.uiPositions.Move("FailedFrame", UIVisibility.Hide);

            Admin.instance.level.levelId++;
        }

        protected override void EnterFailedState()
        {
            UIManager.instance.uiPositions.Move("ReadyFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("GamePlayFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("CompletedFrame", UIVisibility.Hide);
            UIManager.instance.uiPositions.Move("FailedFrame", UIVisibility.Show);
        }
    }
}
