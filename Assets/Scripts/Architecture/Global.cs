using QFramework;
using UnityEngine;

namespace UndeadSurvivorGame
{
    public class Global : Singleton<Global>
    {
        // 极限远点，表示游戏内角色不会接触到的位置
        public static Vector2 OutWorldPoint = new Vector2(1000, 1000);


        // Game Global
        public static BindableProperty<float> GlobalTime = new BindableProperty<float>();

        public static BindableProperty<int> GameLevel = new BindableProperty<int>(1);

        public static BindableProperty<int> EnemyNum = new BindableProperty<int>();

        // Game Player 
        public static BindableProperty<int> KillNum = new BindableProperty<int>();
        public static BindableProperty<int> PlayerLevel = new BindableProperty<int>(1);
        public static BindableProperty<int> Exp = new BindableProperty<int>();

        /// <summary>
        /// 获取最小值和最大值中间的随机Vector3，包含四个象限
        /// </summary>
        /// <returns>随机 Position- Vector3</returns>
        public static Vector3 GetRandomPos(float min, float max)
        {
            var distance = Random.Range(min, max);
            var symbolX = Random.Range(0, 2) == 1 ? 1f : -1f;
            var randomX = symbolX * Random.Range(0, distance);

            var symbolY = Random.Range(0, 2) == 1 ? 1f : -1f;
            var posY = symbolY * Mathf.Sqrt(distance * distance - randomX * randomX);

            Vector3 pos = new Vector3(randomX, posY, 0);
            return pos;
        }
    }
}