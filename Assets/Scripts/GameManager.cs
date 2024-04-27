using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject[] characters;

    private int _charIndex;
    public int CharIndex

    {  get { return _charIndex; }
        set { _charIndex = value; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnlevelFinishedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnlevelFinishedLoading;
    }
    void OnlevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MonsterGame")
        {
            Instantiate(characters[CharIndex]);
        }
    }

}
