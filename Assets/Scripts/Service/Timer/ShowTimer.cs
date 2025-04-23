using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    [SerializeField] private Image _timerImage;
    private float _timeMax;

    private void Start()
    {
        _timerImage.fillAmount = 0f;
    }

    private void OnEnable()
    {
        Timer.OnTime += FillAmountImage;
        Timer.StartTime += SetTimeMax;
    }

    private void OnDisable()
    {
        Timer.OnTime -= FillAmountImage;
        Timer.StartTime -= SetTimeMax;
    }

    private void SetTimeMax(float timeMax)
    {
        _timeMax = timeMax;
    }

    private void FillAmountImage(float timeNow)
    {
        float newfillAmount = timeNow / _timeMax;
        _timerImage.fillAmount = newfillAmount;
    }
}
