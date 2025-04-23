using UnityEngine;

public class AudioDoor : MonoBehaviour
{
    [SerializeField] private AudioClip _soundOpen;
    [SerializeField] private AudioClip _soundClose;
    [SerializeField] private AudioSource _audioSound;

    public void SoundOpen()
    {
        _audioSound.clip = _soundOpen;
        _audioSound.Play();
    }

    public void SoundClose()
    {
        _audioSound.clip = _soundClose;
        _audioSound.Play();
    }
}
