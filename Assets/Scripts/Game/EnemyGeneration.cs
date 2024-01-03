using System;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Timers;
using UndeadSurvivorGame.SO;
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


        public int GameLevel;
        public int EnemyId;
        public float TimeFrequency;

        private Transform mPlayerTrans;
        public float GlobalTime;
        private float mCurrentTime;


        void Start()
        {
            mPlayerTrans = Player.Instance.transform;
            GameLevel = 1;
            mCurrentTime = 0f;
            EnemyId = 0;

            ActionKit.Delay(10f, () =>
            {
                GameLevel += 1;
                EnemyId += 1;
                TimeFrequency *= 0.8f;
                mCurrentTime = 0f;
            }).Start(this);
        }

        private void Update()
        {
            GlobalTime += Time.deltaTime;
            
            mCurrentTime += Time.deltaTime;

            if (mCurrentTime >= TimeFrequency)
            {
                mCurrentTime = 0;
                // var posX = Random.Range(5, 10);
                // var posY = Mathf.Sqrt(100 - posX * posX);
                //
                // var symbolNum = Random.Range(-1, 2) > 0 ? 1 : -1;
                // 产生敌人
                var randomPos = new Vector3(mPlayerTrans.position.x + Random.Range(5f, 10f),
                    mPlayerTrans.position.y + Random.Range(5f, 7f), 0);
                var enemy = Lean.Pool.LeanPool.Spawn(CurrentEnemyPrefab, randomPos, Quaternion.identity, transform)
                    .GetComponent<Enemy>();
                enemy.GenerateInit(EnemyDataList[EnemyId]);
            }
        }
    }
}