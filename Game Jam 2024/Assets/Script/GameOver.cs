using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver = false;
    public GameObject gameOverUI;

    public void Restart()
    {
        gameOverUI.SetActive(false);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }

    public void DisplayGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
}
