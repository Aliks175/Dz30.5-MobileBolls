using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField][Range(0, 0.2f)] private float _force;
    public static event Action<GameObject> Player;

    private void Start()
    {
        Player?.Invoke(rb.gameObject);
    }

    private void OnEnable()
    {
        InputControl.OnMove += Move;
    }

    private void OnDisable()
    {
        InputControl.OnMove -= Move;
    }

    private void Move(Vector2 vector2)
    {
        vector2 = vector2 * _force;
        Vector3 direction = new Vector3(vector2.x, 0, vector2.y);
        rb.AddForce(direction, ForceMode.Impulse);
    }
}
