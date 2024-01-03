using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndeadSurvivorGame.SO
{
    [CreateAssetMenu(menuName = "DATA/Enemy", fileName = "EnemyDataTemplate")]
    public class EnemyDataSO : ScriptableObject
    {
        public int ID;
        public float MaxHealth;
        public float NormalSpeed;
        public float DamageValue;
    }
}