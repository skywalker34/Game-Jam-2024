using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private bool isDead = false;
    private float lastCollideTime;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (health <= 0)
        {
            GameOver();
        }
    }


    void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && Time.time - lastCollideTime > 0.2f)
        {
            lastCollideTime = Time.time;
            health--;
        }
    }

}


