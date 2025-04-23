public class AudioSettings : Singleton<AudioSettings>
{
    public float _volumeMusic = 10f;
    public float _volumeSound = 80f;

    private void Awake()
    {
        if (IsAwake)
        {
            Destroy(gameObject);
        }
        else if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
}
