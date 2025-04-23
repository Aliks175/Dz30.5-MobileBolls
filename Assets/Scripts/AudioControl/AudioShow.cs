using UnityEngine;
using UnityEngine.UI;

public class AudioShow : MonoBehaviour
{
    [SerializeField] private Image ImageSound;
    [SerializeField] private Image ImageMusic;

    private void OnEnable()
    {
        AudioControl.OnImage += Show;
    }

    private void OnDisable()
    {
        AudioControl.OnImage -= Show;
    }

    private void Show(float _sound, float _music)
    {
        ImageSound.fillAmount = _sound * 0.01f;
        ImageMusic.fillAmount = _music * 0.01f;
    }
}
