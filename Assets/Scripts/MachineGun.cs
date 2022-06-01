using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    protected override void CreateBullets()
    {
        GameObject go = Factory.Instance.GetObject(FactoryItem.Bullet);
        BulletController bc = go.GetComponent<BulletController>();
        float randAngle = Random.Range(-dto.Accuracy, dto.Accuracy);
        Quaternion rotation = Quaternion.Euler(
            bulletRespawn.rotation.eulerAngles.x,
            bulletRespawn.rotation.eulerAngles.y,
            bulletRespawn.rotation.eulerAngles.z + randAngle
        );
        bc.Init(10f, 5f, bulletRespawn.position, rotation);
    }
}
