using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class WeaponTests
{
    [Test]
    public void fire_spawns_a_bullet()
    {
        var bulletFabricator = new BulletFabricatorSpy();
        var gun = new Weapon(bulletFabricator);

        Assert.AreEqual(0, bulletFabricator.NumSpawnedBullets());
        gun.Fire();
        Assert.AreEqual(1, bulletFabricator.NumSpawnedBullets());
    }

    class Weapon
    {
        public Weapon(IBulletFabricator bulletFabric_)
        {
            bulletFabric = bulletFabric_;
        }

        IBulletFabricator bulletFabric;
        public void Fire()
        {
            bulletFabric.SpawnBullet();
        }
    }

    interface IBulletFabricator
    {
        public void SpawnBullet();
    }

    class BulletFabricatorSpy : IBulletFabricator
    {
        int _spawnedBullets = 0;
        public int NumSpawnedBullets()
        {
            return _spawnedBullets;
        }

        public void SpawnBullet()
        {
            _spawnedBullets += 1;
        }
    }

}
