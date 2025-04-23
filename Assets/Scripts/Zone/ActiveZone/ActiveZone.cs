using UnityEngine;

public class ActiveZone : MonoBehaviour
{
    [SerializeField] private GameObject Active;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player))
        {
            Active.SetActive(true);
        }
    }
}
