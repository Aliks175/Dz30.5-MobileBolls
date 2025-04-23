using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeMax;
    private float _timeNow;
    private bool _isPlay;
    public static event Action<float> OnTime;
    public static event Action<float> StartTime;

    private void Start()
    {
        StartTime?.Invoke(_timeMax);
        _isPlay = true;
    }

    private void OnEnable()
    {
        End.OffTimer += Play;
    }

    private void OnDisable()
    {
        End.OffTimer -= Play;
    }

    private void TimeForDefeat()
    {
        if (_timeNow < _timeMax)
        {
            _timeNow += Time.deltaTime;
            if (_timeNow > _timeMax) { _timeNow = _timeMax; }
            OnTime?.Invoke(_timeNow);
        }
        else
        {
            Defeat();
        }
    }

    private void Defeat()
    {
        StaticEnd.Active(Final.Defeat);
    }

    public void Play(bool isPlay)
    {
        _isPlay = isPlay;
    }

    void Update()
    {
        if (_isPlay)
        {
            TimeForDefeat();
        }
    }
}
