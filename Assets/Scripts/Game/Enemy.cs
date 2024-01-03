using System;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;
using UndeadSurvivorGame.SO;

namespace UndeadSurvivorGame
{
    public partial class Enemy : ViewController
    {
        [Header("Runtime Variable")] public int PrefabId;
        public float CurSpeed;
        public float MaxHealth;
        public float CurHealth;
        public float CurDamage;

        public List<RuntimeAnimatorController> EnemyAnimatorsList;

        private Vector2 mDirVector2;

        // Animator
        private static readonly int Hit = Animator.StringToHash("hit");

        private void Awake()
        {
            Animator.runtimeAnimatorController = null;
        }

        private void Update()
        {
            if (Player.Instance)
            {
                mDirVector2 = (Player.Instance.transform.position - transform.position).normalized;

                transform.Translate(mDirVector2 * (CurSpeed * Time.deltaTime));
            }

            SpriteDirection();
        }

        public void GenerateInit(EnemyDataSO data)
        {
            PrefabId = data.ID;
            MaxHealth = data.MaxHealth;
            CurDamage = data.DamageValue;
            CurSpeed = data.NormalSpeed;

            CurHealth = MaxHealth;
            Animator.runtimeAnimatorController = EnemyAnimatorsList[PrefabId];
        }

        public void UnderAttack()
        {
            Animator.SetTrigger(Hit);
            Lean.Pool.LeanPool.Despawn(this, 0.5f);
            Global.KillNum.Value++;
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
    }
}