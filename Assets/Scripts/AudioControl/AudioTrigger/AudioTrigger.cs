using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : MonoBehaviour
{
    private AudioSource m_Source;

    private void Start()
    {
        m_Source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ConstTag.Player))
        {
            m_Source.Play();
        }
    }
}
