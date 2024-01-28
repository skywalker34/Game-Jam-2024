using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)Scene.MainMenu);

        }
    }
}