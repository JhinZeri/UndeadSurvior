using System;
using System.Collections.Generic;
using Micosmo.SensorToolkit;
using UnityEngine;
using QFramework;

namespace UndeadSurvivorGame
{
    public partial class WeaponShovel : ViewController
    {
        public RangeSensor2D AttackRange;
        public int ShovelLv;
        public float RotateSpeed;

        public GameObject BulletPrefab;

        public List<ShovelBullet> ListShovel;

        void Start()
        {
            ShovelLv = 1;

            for (int index = 0; index < ShovelLv; index++)
            {
                var bullet = Lean.Pool.LeanPool.Spawn(BulletPrefab, transform).GetComponent<ShovelBullet>();
                ListShovel.Add(bullet);

                Vector3 rotVec = Vector3.forward * 360 / ShovelLv * index;

                var trans = bullet.transform;
                trans.Rotate(rotVec);
                trans.Translate(trans.up * 1.5f, Space.World);
            }
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, -30) * (RotateSpeed * Time.deltaTime));
        }

        public void Upgrade()
        {
            ShovelLv += 1;
            RotateSpeed += 1;

            foreach (var obj in ListShovel)
            {
                Lean.Pool.LeanPool.Despawn(obj.gameObject);
            }

            var number = ShovelLv;

            ListShovel.Clear();
            for (int index = 0; index < number; index++)
            {
                var bullet = Lean.Pool.LeanPool.Spawn(BulletPrefab, transform).GetComponent<ShovelBullet>();
                ListShovel.Add(bullet);

                Vector3 rotVec = Vector3.forward * 360 / number * index;

                var trans = bullet.transform;
                trans.Rotate(rotVec);
                trans.Translate(trans.up * 1.5f, Space.World);
            }
        }
    }
}