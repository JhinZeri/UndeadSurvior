using System;
using Micosmo.SensorToolkit;
using UnityEngine;
using QFramework;

namespace UndeadSurvivorGame
{
    public partial class WeaponShovel : ViewController
    {
        public RangeSensor2D AttackRange;
        public float RotateSpeed;

        void Start()
        {
            // Code Here
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, 0, -30) * (RotateSpeed * Time.deltaTime));
        }
    }
}