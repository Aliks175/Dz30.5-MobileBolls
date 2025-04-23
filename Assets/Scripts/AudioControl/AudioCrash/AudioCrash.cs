using UnityEngine;
public class AudioCrash : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstTag.Box))
        {
            m_AudioSource.Play();
        }
    }
}
