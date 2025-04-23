using System;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _starPanel;
    private GameObject _player;
    public static event Action<bool> OffTimer;

    private void OnEnable()
    {
        Mover.Player += SetPlayer;
        StaticEnd.ResultatEnd += Resultat;
    }

    private void OnDisable()
    {
        Mover.Player -= SetPlayer;
        StaticEnd.ResultatEnd -= Resultat;
    }

    private void SetPlayer(GameObject player)
    {
        if (_player == null)
            _player = player;
    }

    private void OpenMenu(GameObject menuPanel)
    {
        menuPanel.SetActive(true);
        _starPanel.SetActive(true);
        _player.SetActive(false);
    }

    private void Resultat(Final final)
    {
        OffTimer?.Invoke(false);
        switch (final)
        {
            case Final.Win:
                OpenMenu(_winPanel);
                break;
            case Final.Defeat:
                OpenMenu(_defeatPanel);
                break;
        }
    }
}

public enum Final
{
    Win,
    Defeat
}
