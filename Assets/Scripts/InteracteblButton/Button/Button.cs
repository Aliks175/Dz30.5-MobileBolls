using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private Material _active;
    [SerializeField] private Material _deactive;
    [SerializeField] private Animator _door;
    public static event Action onSound;
    private int enterIndex;

    private void Start()
    {
        enterIndex = 0;
        m_Renderer.material = _deactive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player) || other.gameObject.CompareTag(ConstTag.Box))
        {
            enterIndex++;
            OnActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player) || other.gameObject.CompareTag(ConstTag.Box))
        {
            enterIndex--;
            if (enterIndex <= 0)
            {
                OFFDeactive();
                enterIndex = 0;
            }
        }
    }

    private void OnActive()
    {
        m_Renderer.material = _active;
        _door.SetBool("Close", false);
        onSound();
    }

    private void OFFDeactive()
    {
        m_Renderer.material = _deactive;
        _door.SetBool("Close", true);
        onSound();
    }
}
