using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace example
{
    public class GamePlay : MonoBehaviour
    {
        public static GamePlay instance;
        public int currentNum = 1;

        public Dot[] dots = new Dot[4];

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

        public void Reset()
        {
            currentNum = 1;
        }

        public void ClickDot(Dot dot)
        {
            if (Admin.instance.state != GameState.GamePlay)
            {
                return;
            }

            if (currentNum != dot.id)
            {
                Admin.instance.state = GameState.Failed;
            }
            else
            {
                Destroy(dot.gameObject);
                currentNum++;
            }

            if (currentNum > 4)
            {
                Admin.instance.state = GameState.Completed;
            }
        }
    }
}
