using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 Vector3;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3);
    }
}
