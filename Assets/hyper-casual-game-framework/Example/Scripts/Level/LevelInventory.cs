using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace example
{
    public class LevelInventory : MonoBehaviour
    {
        public static LevelInventory instance;

        public GameObject[] dotPrefabs;

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
    }
}

