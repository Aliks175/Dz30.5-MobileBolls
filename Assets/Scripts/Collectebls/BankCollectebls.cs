using System;
using UnityEngine;

public class BankCollectebls : MonoBehaviour
{
    public int StarBalance { get; private set; }
    public static event Action UpDateBank;

    private void OnDisable()
    {
        Upper.OnUp -= TakeUp;
    }

    private void OnEnable()
    {
        Upper.OnUp += TakeUp;

    }

    private void TakeUp()
    {
        StarBalance++;
        UpdateCollectebls();
    }

    private void UpdateCollectebls()
    {
        UpDateBank?.Invoke();
    }
}