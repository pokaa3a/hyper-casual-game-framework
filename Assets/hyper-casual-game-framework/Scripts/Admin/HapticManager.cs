using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ref:
// https://forum.unity.com/threads/guide-haptic-feedback-on-android-with-no-plugin.382384/

public class HapticManager : MonoBehaviour
{
    public static HapticManager instance;

    public bool hapticOn
    {
        get { return PlayerPrefs.GetInt(Prefs.HAPTIC, Prefs.HAPTIC_ON) == Prefs.HAPTIC_ON; }
        set
        {
            int newValue = value ? Prefs.HAPTIC_ON : Prefs.HAPTIC_OFF;
            PlayerPrefs.SetInt(Prefs.HAPTIC, newValue);
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private int HapticFeedbackConstantsKey;
    private AndroidJavaObject UnityPlayer;
#endif

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
#if UNITY_ANDROID && !UNITY_EDITOR
            HapticFeedbackConstantsKey = new AndroidJavaClass("android.view.HapticFeedbackConstants").GetStatic<int>("VIRTUAL_KEY");
            UnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer");
            //Alternative way to get the UnityPlayer:
            //int content=new AndroidJavaClass("android.R$id").GetStatic<int>("content");
            //new AndroidJavaClass ("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("findViewById",content).Call<AndroidJavaObject>("getChildAt",0);
#endif
    }

    public void Vibrate()
    {
        if (hapticOn)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            UnityPlayer.Call<bool> ("performHapticFeedback",HapticFeedbackConstantsKey);
#endif
        }
    }
}
