using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager2
{
    public enum Sound
    {
        ButtonClick,
        ButtonOver,
        SnakeDie,
        SnakeEat,
        SnakeMove
    }

    private static GameObject soundManagerGameObject;
    private static AudioSource audioSource;

    public static void CreateSoundManagerGameObject()
    {
        if (soundManagerGameObject == null)
        {
            soundManagerGameObject = new GameObject("Sound Manager");
            audioSource = soundManagerGameObject.AddComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Sound Manager already exists");
        }
    }

    public static void PlaySound(Sound sound2)
    {
        audioSource.PlayOneShot(GetAudioClipFromSound(sound2));
    }

    private static AudioClip GetAudioClipFromSound(Sound sound2)
    {
        foreach (GameAssets2.SoundAudioClip2 soundAudioClip2 in GameAssets2.Instance.soundAudioClipsArray)
        {
            if (soundAudioClip2.sound2 == sound2)
            {
                return soundAudioClip2.audioClip;
            }
        }
        Debug.LogError("Sound " + sound2 + " not found");
        return null;
    }
}
