using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private AudioSource _audioSound;

    private void OnEnable()
    {
        Button.onSound += Play;
    }

    private void OnDisable()
    {
        Button.onSound -= Play;
    }

    public void Play()
    {
        _audioSound.clip = _sound;
        _audioSound.Play();
    }
}