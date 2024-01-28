using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0: // Level 1
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(1);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(2);
                        break;
                    }
                    break;
                }
            case 1: // Level 2.a
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(3);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    { 
                        SceneManager.LoadScene(4);
                        break;
                    }
                    break;
                }
            case 2: // Level 2.b
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(4);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(5);
                        break;
                    }
                    break;
                }
            case 3: // Level 3.a
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(6);
                        break;
                    }
                    break;
                }
            case 4: // Level 3.b
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //currentLevel = Levels.level2_a;
                        SceneManager.LoadScene(6);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(7);
                        break;
                    }
                    break;
                }
            case 5: // Level 3.c
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(7);
                        break;
                    }
                    break;
                }
            case 6: // Level 4.a
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(8);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(9);
                        break;
                    }
                    break;
                }
            case 7: // Level 4.b
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SceneManager.LoadScene(9);
                        break;
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        SceneManager.LoadScene(10);
                        break;
                    }
                    break;
                }
            case 8: // Level Boss.a
                {
                    break;
                }
            case 9: // Level Boss.b
                {
                    break;
                }
            case 10: // Level Boss.c
                {
                    break;
                }



        }
    }
}