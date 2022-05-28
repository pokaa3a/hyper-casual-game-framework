using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Victory
};

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip victory;

    private AudioSource audioSource;

    private float volume = 1f;

    public bool soundOn
    {
        get { return PlayerPrefs.GetInt(Prefs.SOUND, Prefs.SOUND_ON) == Prefs.SOUND_ON; }
        set
        {
            int newValue = value ? Prefs.SOUND_ON : Prefs.SOUND_OFF;
            PlayerPrefs.SetInt(Prefs.SOUND, newValue);

            volume = value ? 1f : 0f;
            audioSource.mute = !value;
        }
    }

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
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioType type)
    {
        if (!soundOn) return;

        AudioClip clip;
        switch (type)
        {
            case AudioType.Victory:
                clip = victory;
                break;
            default:
                clip = victory;
                break;
        }
        audioSource.PlayOneShot(clip, volume);
    }
}
