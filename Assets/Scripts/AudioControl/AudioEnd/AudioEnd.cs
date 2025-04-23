using UnityEngine;

public class AudioEnd : MonoBehaviour
{
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _defeatClip;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        StaticEnd.ResultatEnd += Play;
    }

    private void OnDisable()
    {
        StaticEnd.ResultatEnd -= Play;
    }

    private void Play(Final final)
    {
        if (final == Final.Win)
        {
            ChangeSound(_winClip);
        }
        else if (final == Final.Defeat)
        {
            ChangeSound(_defeatClip);
        }
    }

    private void ChangeSound(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
