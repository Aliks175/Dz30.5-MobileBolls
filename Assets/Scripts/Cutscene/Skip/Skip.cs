using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    [SerializeField] private float _maxTimeSkip;
    [SerializeField] private List<GameObject> _deactive;
    [SerializeField] private List<GameObject> _active;
    [SerializeField] private Image _imageSkip;
    private float _NowTime;
    private bool _isPlay = true;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        _NowTime = 0f;
        _imageSkip.fillAmount = 0f;
    }

    private void Update()
    {
        if (_isPlay)
        {
            LongTouch();
        }
    }

    public void Play(bool isPlay)
    {
        if (!isPlay) { Restart(); }
        _isPlay = isPlay;
    }

    private void LongTouch()
    {
        if (Input.touchCount > 0)
        {
            if (_NowTime < _maxTimeSkip)
            {
                _NowTime += Time.deltaTime;
                if (_NowTime > _maxTimeSkip) { _NowTime = _maxTimeSkip; }
                ImageShow();
            }
            else
            {
                ResultTouch(_deactive, false);
                ResultTouch(_active, true);
                Restart();
                _isPlay = false;
            }
        }
        else
        {
            if (_NowTime > 0)
            {
                _NowTime -= Time.deltaTime;
                if (_NowTime < 0) { _NowTime = 0; }
                ImageShow();
            }
        }
    }

    private void ResultTouch(List<GameObject> objects, bool setActive)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(setActive);
        }
    }

    private void ImageShow()
    {
        _imageSkip.fillAmount = _NowTime / _maxTimeSkip;
    }
}
