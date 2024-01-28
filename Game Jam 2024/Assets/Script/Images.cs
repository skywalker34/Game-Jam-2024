using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images: MonoBehaviour
{
    public int Ability;
    public int DiffAbility;

    public Image[] Abilities;
    public Sprite LEyes;
    public Sprite Chicken;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Ability -= 1;
        }

        for (int i = 0; i < Abilities.Length; i++)
        {
            if (i < Ability)
            {
                Abilities[i].sprite = LEyes;
            }
            else
            {
                Abilities[i].sprite = Chicken;
            }
        }
    }
}


