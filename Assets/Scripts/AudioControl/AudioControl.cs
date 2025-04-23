using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    private List<AudioSource> _music = new List<AudioSource>();
    private List<AudioSource> _sound = new List<AudioSource>();
    private float _volumeMusic;
    private float _volumeSound;
    public static event Action<float, float> OnImage;

    void Start()
    {
        SetStartSettings();
    }

    private void FindVolumeSettings()
    {
        _volumeMusic = AudioSettings.Instance._volumeMusic;
        _volumeSound = AudioSettings.Instance._volumeSound;
    }

    private void SetStartSettings()
    {
        FindVolumeSettings();
        FindSourse();
        SetStartVolume();
    }

    private void SetStartVolume()
    {
        OnImage(_volumeSound, _volumeMusic);
        Save();
        SetVolume(_music, _volumeMusic * 0.01f);
        SetVolume(_sound, _volumeSound * 0.01f);
    }

    private void SetVolume(List<AudioSource> audioSources, float volume)
    {
        if (audioSources == null) { return; }
        foreach (AudioSource source in audioSources)
        {
            source.volume = volume;
        }
    }

    private void FindSourse()
    {
        GameObject[] arrayMusicGameObjects = GameObject.FindGameObjectsWithTag(ConstTag.MusicSource);
        GameObject[] arraySoundGameObjects = GameObject.FindGameObjectsWithTag(ConstTag.SoundSource);
        if (arrayMusicGameObjects != null)
        {
            GetAudioSource(arrayMusicGameObjects, _music);
        }
        if (arraySoundGameObjects != null)
        {
            GetAudioSource(arraySoundGameObjects, _sound);
        }
    }

    private void GetAudioSource(GameObject[] gameObjects, List<AudioSource> audioSources)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            audioSources.Add(gameObject.GetComponent<AudioSource>());
        }
    }

    public void MusicVolume(bool isUp)
    {
        if (isUp)
        {
            _volumeMusic += 5f;
            if (_volumeMusic >= 100f) { _volumeMusic = 100f; }
        }
        else
        {
            _volumeMusic -= 5f;
            if (_volumeMusic <= 0f) { _volumeMusic = 0f; }
        }
        SetVolume(_music, _volumeMusic * 0.01f);
        OnImage(_volumeSound, _volumeMusic);
        Save();
    }

    public void SoundVolume(bool isUp)
    {
        if (isUp)
        {
            _volumeSound += 5f;
            if (_volumeSound >= 100f) { _volumeSound = 100f; }
        }
        else
        {
            _volumeSound -= 5f;
            if (_volumeSound <= 0f) { _volumeSound = 0f; }
        }
        SetVolume(_sound, _volumeSound * 0.01f);
        OnImage(_volumeSound, _volumeMusic);
        Save();
    }

    private void Save()
    {
        AudioSettings.Instance._volumeMusic = _volumeMusic;
        AudioSettings.Instance._volumeSound = _volumeSound;
    }
}