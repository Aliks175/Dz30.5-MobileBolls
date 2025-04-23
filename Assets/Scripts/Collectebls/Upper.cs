using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Upper : MonoBehaviour
{
    [SerializeField] Collider _circleCollider;
    [SerializeField] private GameObject _star;
    [SerializeField] private float _time;
    private bool isUse = false;
    public static event Action OnUp;

    private void Start()
    {
        if (_circleCollider == null)
        {
            _circleCollider = gameObject.GetComponent<Collider>();
        }
    }
    /// <summary>
    /// Проверяет чтобы тригер отработал 1 раз , проверяет что взаимодействует игрок по тэгу вызывает ивент Up и уничтожается
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (isUse) return;
        if (other.CompareTag(ConstTag.Player))
        {
            isUse = true;
            OnUp?.Invoke();
            Up();
        }
    }

    private IEnumerator TimeOff(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void Up()
    {
        _star.SetActive(false);
        _circleCollider.enabled = false;
        StartCoroutine(TimeOff(_time));
    }
}
