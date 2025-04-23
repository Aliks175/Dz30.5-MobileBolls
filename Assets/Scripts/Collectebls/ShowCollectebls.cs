using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCollectebls : MonoBehaviour
{
    [SerializeField] private BankCollectebls bankCollectebls;
    [SerializeField] private List<Image> _stars;

    private void Start()
    {
        Show(0);
    }

    private void OnEnable()
    {
        BankCollectebls.UpDateBank += NewChange;
    }

    private void OnDisable()
    {
        BankCollectebls.UpDateBank -= NewChange;
    }

    private void NewChange()
    {
        Show(bankCollectebls.StarBalance);
    }

    private void Show(int valueStars)
    {
        for (int i = 0; i < valueStars; i++)
        {
            _stars[i].color = Color.white;
        }
    }
}
