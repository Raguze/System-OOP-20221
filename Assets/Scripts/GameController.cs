using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Item item;
    public Weapon weapon;

    void Start()
    {
        item = new Item();
        item.Name = "Potion";

        weapon = new Weapon()
        {
            Name = "Pistol",
            Damage = 10
        };
    }
}
