using System;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Timers;
using UndeadSurvivorGame.SO;
using UndeadSurvivorGame.Utility;
using Random = UnityEngine.Random;

namespace UndeadSurvivorGame
{
    [Serializable]
    public class EnemyWaveData
    {
        public int Id;
        public float Frequency;
    }

    public partial class EnemyGeneration : ViewController
    {
        public List<EnemyDataSO> EnemyDataList = new List<EnemyDataSO>();
        public List<EnemyWaveData> EnemyWaveList = new List<EnemyWaveData>();
        public GameObject CurrentEnemyPrefab;

        public int EnemyId;
        public float TimeFrequency;

        private Transform mPlayerTrans;
        private float mCurrentTime;

        void Start()
        {
            mPlayerTrans = Player.Instance.transform;

            mCurrentTime = 0f;
            EnemyId = 0;

            Global.GameLevel.RegisterWithInitValue(lv =>
            {
                TimeFrequency = Global.GameLevel.Value switch
                {
                    1 => 2f,
                    2 => 1.5f,
                    3 => 1f,
                    _ => TimeFrequency
                };
            });
        }

        private void Update()
        {
            Global.GlobalTime.Value += Time.deltaTime;
            Global.EnemyNum.Value =
                FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;
            mCurrentTime += Time.deltaTime;

            if (mCurrentTime >= TimeFrequency)
            {
                mCurrentTime = 0;

                EnemyId = Global.GameLevel.Value switch
                {
                    1 => 0,
                    2 => Random.Range(0, 2),
                    3 => 1,
                    _ => EnemyId
                };

                var randomPos = (Vector2)mPlayerTrans.position +
                                this.GetUtility<RandomCalculateUtility>().RandomDistanceAndPos(10f, 15f);
                var enemy = Lean.Pool.LeanPool.Spawn(CurrentEnemyPrefab, randomPos, Quaternion.identity, transform)
                    .GetComponent<Enemy>();

                // Global.EnemyNum.Value++;
                enemy.GenerateInit(EnemyDataList[EnemyId]);
            }
        }
    }
}