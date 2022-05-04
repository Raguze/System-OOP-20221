using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDTO",menuName = "DTO/WeaponDTO")]
public class WeaponDTO : ItemDTO
{
    public int Damage;
    public float FireRate;
    public float ReloadTime;
    public int AmmoMax;
    public float Distance;
    public float Speed;
    public float Accuracy;
}
