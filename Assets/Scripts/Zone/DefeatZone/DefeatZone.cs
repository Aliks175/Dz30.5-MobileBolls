using UnityEngine;

public class DefeatZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTag.Player))
        {
            StaticEnd.Active(Final.Defeat);
        }
    }
}

