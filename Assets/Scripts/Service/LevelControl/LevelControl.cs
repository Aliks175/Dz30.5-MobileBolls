using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private string _nameLevel;
    private int _levelIndex;

    private void Start()
    {
        _levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Load()
    {
        SceneManager.LoadScene(_nameLevel);
    }

    public void Reload()
    {
        SceneManager.LoadScene(_levelIndex);
    }

    public void Next()
    {
        if (SceneManager.sceneCountInBuildSettings > _levelIndex + 1)
        {
            SceneManager.LoadScene(_levelIndex + 1);
        }
        else
        {
            Load();
        }
    }
}
