using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTag.Player))
        {
            StaticEnd.Active(Final.Win);
        }
    }
}
