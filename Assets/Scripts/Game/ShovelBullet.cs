using System;
using Micosmo.SensorToolkit;
using UnityEngine;

namespace UndeadSurvivorGame
{
    public class ShovelBullet : MonoBehaviour
    {
        private RangeSensor2D mRangeSensor;

        private void Awake()
        {
            mRangeSensor = GetComponent<RangeSensor2D>();

            mRangeSensor.OnDetected.AddListener(FindEnemy);
        }

        private void Update()
        {
            mRangeSensor.Pulse();
        }

        private void OnDestroy()
        {
            mRangeSensor.OnDetected.RemoveAllListeners();
        }
        
        private void FindEnemy(GameObject obj, Sensor sensor)
        {
            var enemyGo = obj;
            if (obj.CompareTag("Enemy"))
            {
                var enemy = obj.GetComponentInParent<Enemy>();

                Debug.Log("找到Enemy！");

                enemy.UnderAttack();
            }
        }
    }
}