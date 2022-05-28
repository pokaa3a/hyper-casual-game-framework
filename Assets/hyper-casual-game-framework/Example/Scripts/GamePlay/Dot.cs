using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace example
{
    public class Dot : MonoBehaviour
    {
        public int id = 1;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>() as Button;
        }

        private void Start()
        {
            button.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            GamePlay.instance.ClickDot(this);
        }
    }
}
