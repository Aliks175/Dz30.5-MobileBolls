using Cinemachine;
using UnityEngine;

public class TargetZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    [SerializeField] private int Priority;
    [SerializeField] private bool _playOnAwake;
    [SerializeField] private bool _OffCameraExit;

    void Start()
    {
        m_Camera.gameObject.SetActive(_playOnAwake);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player))
        {
            OnActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player))
        {
            OffDeactive();
        }
    }

    private void OnActive()
    {
        m_Camera.gameObject.SetActive(true);
        m_Camera.Priority = Priority;
    }

    private void OffDeactive()
    {
        if (_OffCameraExit)
        {
            m_Camera.gameObject.SetActive(false);
            m_Camera.Priority = 0;
        }
    }
}
