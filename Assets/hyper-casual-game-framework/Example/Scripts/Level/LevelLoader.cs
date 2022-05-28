using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace example
{
    public class LevelLoader : LevelLoaderBase
    {
        private GameObject gamePlayObj;

        public LevelLoader()
        {
            gamePlayObj = GameObject.Find("GamePlay");
        }

        public override void LoadLevel(int lvId)
        {
            if (lvId > Admin.instance.level.maxLevelId)
            {
                return;
            }

            EraseLevel();

            TextAsset jsonFile = Resources.Load<TextAsset>($"LevelConfigJson/Level{lvId}");
            LevelConfigJson config = JsonUtility.FromJson<LevelConfigJson>(jsonFile.ToString());

            // Construct level here
            GameObject dots = new GameObject("Dots");
            dots.transform.SetParent(gamePlayObj.transform);
            dots.AddComponent<RectTransform>().anchoredPosition = Vector2.zero;
            const float step = 200f;

            GameObject dot1 = Object.Instantiate(LevelInventory.instance.dotPrefabs[0]);
            dot1.transform.SetParent(dots.transform);
            Vector2 dot1Pos = new Vector2(config.dot1Pos[0], config.dot1Pos[1]);
            dot1.GetComponent<RectTransform>().anchoredPosition = dot1Pos * step - (Vector2.one * step / 2f);

            GameObject dot2 = Object.Instantiate(LevelInventory.instance.dotPrefabs[1]);
            dot2.transform.SetParent(dots.transform);
            Vector2 dot2Pos = new Vector2(config.dot2Pos[0], config.dot2Pos[1]);
            dot2.GetComponent<RectTransform>().anchoredPosition = dot2Pos * step - (Vector2.one * step / 2f);

            GameObject dot3 = Object.Instantiate(LevelInventory.instance.dotPrefabs[2]);
            dot3.transform.SetParent(dots.transform);
            Vector2 dot3Pos = new Vector2(config.dot3Pos[0], config.dot3Pos[1]);
            dot3.GetComponent<RectTransform>().anchoredPosition = dot3Pos * step - (Vector2.one * step / 2f);

            GameObject dot4 = Object.Instantiate(LevelInventory.instance.dotPrefabs[3]);
            dot4.transform.SetParent(dots.transform);
            Vector2 dot4Pos = new Vector2(config.dot4Pos[0], config.dot4Pos[1]);
            dot4.GetComponent<RectTransform>().anchoredPosition = dot4Pos * step - (Vector2.one * step / 2f);
        }

        public override void EraseLevel()
        {
            foreach (Transform child in gamePlayObj.transform)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}
