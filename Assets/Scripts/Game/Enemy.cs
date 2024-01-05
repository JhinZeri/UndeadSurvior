using System;
using System.Collections.Generic;
using Micosmo.SensorToolkit;
using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using UndeadSurvivorGame.SO;

namespace UndeadSurvivorGame
{
    public partial class Enemy : ViewController
    {
        public bool IsTest;

        [Header("Runtime Variable")] public int PrefabId;
        public float CurSpeed;
        public float MaxHealth;
        public float CurHealth;
        public float CurDamage;

        public List<RuntimeAnimatorController> EnemyAnimatorsList;

        private Vector2 mDirVector2;


        public bool IsDead;
        public bool IsContactPlayer;
        public float RepeatAttackTime;
        public float ContactTime;

        // Animator
        private static readonly int Hit = Animator.StringToHash("hit");

        private void Awake()
        {
            if (!IsTest)
                Animator.runtimeAnimatorController = null;
        }

        private void Update()
        {
            BodySensor.Pulse();

            if (Player.Instance && !IsContactPlayer)
            {
                mDirVector2 = (Player.Instance.transform.position - transform.position).normalized;

                transform.Translate(mDirVector2 * (CurSpeed * Time.deltaTime));
            }

            if (IsContactPlayer)
            {
                ContactTime += Time.deltaTime;
                if (ContactTime >= RepeatAttackTime)
                {
                    ContactTime = 0;
                    Player.Instance.GetHurt(CurDamage);
                }
            }
        }

        private void LateUpdate()
        {
            SpriteDirection();
        }

        public void GenerateInit(EnemyDataSO data)
        {
            //  恢复Sprite层级
            // Sprite.sortingLayerID = SortingLayer.GetLayerValueFromName("Default");
            // Sprite.sortingOrder = 1;

            PrefabId = data.ID;
            MaxHealth = data.MaxHealth;
            CurDamage = data.DamageValue;
            CurSpeed = data.NormalSpeed;

            CurHealth = MaxHealth;
            Animator.runtimeAnimatorController = EnemyAnimatorsList[PrefabId];
            IsDead = false;
        }


        public void UnderAttack(float damage)
        {
            if (IsDead)
                return;

            Animator.SetTrigger(Hit);

            CurHealth -= damage;
            if (CurHealth <= 0)
            {
                Dead();
            }
        }

        public void Dead()
        {
            Global.KillNum.Value++;
            Global.Exp.Value++;
            // Global.EnemyNum.Value--;

            // Sprite.sortingLayerID = SortingLayer.GetLayerValueFromName("Background");
            // Sprite.sortingOrder = 0;

            // transform.position = Global.OutWorldPoint;

            IsDead = true;
            // todo: Sensor可能出现对象池的问题
            Lean.Pool.LeanPool.Despawn(this, 0.3f);
        }

        private void SpriteDirection()
        {
            if (mDirVector2.x > 0)
            {
                Sprite.flipX = false;
            }

            if (mDirVector2.x < 0)
            {
                Sprite.flipX = true;
            }
        }

        #region UnityEvent

        public void ContactPlayer(GameObject obj, Sensor sensor)
        {
            Player.Instance.GetHurt(CurDamage);
            IsContactPlayer = true;
        }

        public void LostContactPlayer(GameObject obj, Sensor sensor)
        {
            IsContactPlayer = false;
            ContactTime = 0;
        }

        #endregion
    }
}