using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class Weapon : Item
{
    private Transform bulletRespawn;

    public WeaponDTO dto;

    public BulletController bulletPrefab;

    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public float ReloadTime { get; protected set; }
    public int AmmoMax { get; protected set; }
    public float Distance { get; protected set; }
    public float Speed { get; protected set; }
    public float Accuracy { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        bulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");

        Transform[] children = tf.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if(child.name == "BulletRespawn")
            {
                bulletRespawn = child;
                break;
            }
        }
    }

    public virtual void Init(WeaponDTO wdto)
    {
        dto = wdto;
        Damage = wdto.Damage;
        FireRate = wdto.FireRate;
        ReloadTime = wdto.ReloadTime;
        AmmoMax = wdto.AmmoMax;
        Distance = wdto.Distance;
        Speed = wdto.Speed;
        Accuracy = wdto.Accuracy;
    }

    public virtual void Fire()
    {
        //BulletController bulletController = Instantiate<BulletController>(bulletPrefab, bulletRespawn.position, tf.rotation);
        //bulletController.Init(10f, 3f);
        GameObject go = Factory.Instance.Create("bullet", bulletRespawn.position, tf.rotation);
        BulletController bc = go.GetComponent<BulletController>();
        bc.Init(10f, 3f);
    }
}
