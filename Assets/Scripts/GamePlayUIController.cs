using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MonsterGame");
        //another way to get current scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HomePage()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
}
