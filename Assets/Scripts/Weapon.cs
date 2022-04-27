using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class Weapon : Item
{
    private Transform bulletRespawn;

    public int Damage;

    public BulletController bulletPrefab;


    // Damage
    // FireRate
    // ReloadTime
    // AmmoMax
    // Distance
    // Speed
    // Accuracy

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

    public void Init(WeaponDTO dto)
    {

    }

    public void Fire()
    {
        BulletController bulletController = Instantiate<BulletController>(bulletPrefab, bulletRespawn.position, tf.rotation);
        bulletController.Init(10f, 3f);
    }
}
