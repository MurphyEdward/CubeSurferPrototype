using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    private static bool _isGamePaused;
    public static bool IsGamePaused
    {
        get
        {
            return _isGamePaused;
        }
        set
        {
            _isGamePaused = value;
        }
    }

    private void OnEnable()
    {
        CubeRaycast.OnGameOver += PauseGame;
    }
    private void OnDisable()
    {
        CubeRaycast.OnGameOver -= PauseGame;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        _isGamePaused = true;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        _isGamePaused = false;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    
}
