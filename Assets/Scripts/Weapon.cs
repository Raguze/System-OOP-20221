using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public abstract class Weapon : Item
{
    protected Transform bulletRespawn;

    public WeaponDTO dto;

    public BulletController bulletPrefab;

    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public float ReloadTime { get; protected set; }
    public int AmmoMax { get; protected set; }
    public float Distance { get; protected set; }
    public float Speed { get; protected set; }
    public float Accuracy { get; protected set; }

    private bool isFireRateCooldown;

    public bool CanFire 
    { 
        get
        {
            return !isFireRateCooldown;
        } 
    }

    protected override void Awake()
    {
        base.Awake();

        //bulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");

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

    IEnumerator FireRateCooldown()
    {
        Debug.Log($"Fire Rate {FireRate}");
        isFireRateCooldown = true;
        yield return new WaitForSeconds(FireRate);
        isFireRateCooldown = false;
    }

    public virtual void Fire()
    {
        if(!CanFire)
        {
            return;
        }

        StartCoroutine(FireRateCooldown());

        CreateBullets();
    }

    protected virtual void CreateBullets()
    {
        GameObject go = Factory.Instance.GetObject(FactoryItem.Bullet);
        BulletController bc = go.GetComponent<BulletController>();
        bc.Init(10f, 5f, bulletRespawn.position, bulletRespawn.rotation);
    }
}
