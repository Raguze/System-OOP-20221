using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int Pellets { get; protected set; }
    public float Spread { get; protected set; }

    public override void Init(WeaponDTO wdto)
    {
        base.Init(wdto);

        ShotgunDTO sdto = wdto as ShotgunDTO;
        Pellets = sdto.Pellets;
        Spread = sdto.Spread;
    }

    protected override void CreateBullets()
    {
        float angle = bulletRespawn.rotation.eulerAngles.z;
        Debug.Log(angle);
        float angle0 = angle - (Spread / 2);
        float angleStep = Spread / (Pellets - 1);
        for (int i = 0; i < Pellets; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle0 + angleStep * i);
            GameObject go = Factory.Instance.GetObject(FactoryItem.Bullet);
            BulletController bc = go.GetComponent<BulletController>();
            bc.Init(10f, 5f, bulletRespawn.position, rotation);
        }
    }
}
