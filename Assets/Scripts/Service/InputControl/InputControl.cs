using System;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public static event Action<Vector2> OnMove;
    private Vector2 m_Position;
    private bool isTouch = false;

    private void Update()
    {
        ChangeDirections();
    }
    /// <summary> 
    /// Считывает изменения положения касания по X/Y экрана устройства
    /// </summary>
    private void ChangeDirections()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            m_Position = touch.deltaPosition;
            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
    }

    private void FixedUpdate()
    {
        if (isTouch)
            OnMove?.Invoke(m_Position);
    }
}
