using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace example
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public List<UIPosition> uiPositions;

        private UISound uiSound;
        private UIHaptic uiHaptic;

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

            uiSound = new UISound();
            uiHaptic = new UIHaptic();
        }

        #region button_update

        public void UpdateLevelUI()
        {
            GameObject go = GameObject.Find("Text Level");
            Text text = go.GetComponent<Text>() as Text;
            text.text = $"Level: {Admin.instance.level.levelId}";
        }

        #endregion

        #region button_click

        public void ClickSettings()
        {
            uiPositions.Move("SettingsPanel", UIVisibility.Show);
        }

        public void ClickSettingsPanelClose()
        {
            uiPositions.Move("SettingsPanel", UIVisibility.Hide);
        }

        public void ClickSound()
        {
            uiSound.isOn ^= true;
        }

        public void ClickHaptic()
        {
            uiHaptic.isOn ^= true;
        }

        public void ClickToPlay()
        {
            Admin.instance.state = GameState.GamePlay;
        }

        public void ClickToReady()
        {
            Admin.instance.state = GameState.Ready;
        }

        #endregion
    }

    public class UISound
    {
        GameObject gameObject;
        GameObject onObj;
        GameObject offObj;

        public UISound()
        {
            gameObject = GameObject.Find("Sound").gameObject;
            onObj = gameObject.transform.Find("On").gameObject;
            offObj = gameObject.transform.Find("Off").gameObject;
        }

        public bool isOn
        {
            get
            {
                int res = PlayerPrefs.GetInt(Prefs.SOUND, Prefs.SOUND_ON);
                return res == Prefs.SOUND_ON;
            }
            set
            {
                int res = value ? Prefs.SOUND_ON : Prefs.SOUND_OFF;
                PlayerPrefs.SetInt(Prefs.SOUND, res);

                // Update UI
                if (value)
                {
                    onObj.SetActive(true);
                    offObj.SetActive(false);
                }
                else
                {
                    onObj.SetActive(false);
                    offObj.SetActive(true);
                }
            }
        }
    }

    public class UIHaptic
    {
        GameObject gameObject;
        GameObject onObj;
        GameObject offObj;

        public UIHaptic()
        {
            gameObject = GameObject.Find("Haptic").gameObject;
            onObj = gameObject.transform.Find("On").gameObject;
            offObj = gameObject.transform.Find("Off").gameObject;
        }

        public bool isOn
        {
            get
            {
                int res = PlayerPrefs.GetInt(Prefs.HAPTIC, Prefs.HAPTIC_ON);
                return res == Prefs.HAPTIC_ON;
            }
            set
            {
                int res = value ? Prefs.HAPTIC_ON : Prefs.HAPTIC_OFF;
                PlayerPrefs.SetInt(Prefs.HAPTIC, res);

                // Update UI
                if (value)
                {
                    onObj.SetActive(true);
                    offObj.SetActive(false);
                }
                else
                {
                    onObj.SetActive(false);
                    offObj.SetActive(true);
                }
            }
        }
    }
}
