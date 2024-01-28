using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scene
{
    MainMenu,
    Controls,
    LevelOne,
    LevelTwo,
}

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene((int)Scene.LevelOne);
    }

    public void ControlsOption()
    {
        SceneManager.LoadScene((int)Scene.Controls);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
