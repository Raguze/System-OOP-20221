using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Item item;
    public Weapon weapon;

    private InputController ic;

    private void Awake()
    {
        ic = gameObject.AddComponent<InputController>();
    }
}
