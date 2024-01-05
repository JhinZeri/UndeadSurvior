using QFramework;
using UnityEngine;

namespace UndeadSurvivorGame.Utility
{
    public class RandomCalculateUtility : IUtility
    {
        /// <summary>
        /// 随机距离和位置，生成位置是一个环形
        /// </summary>
        public Vector2 RandomDistanceAndPos(float min, float max)
        {
            // 首先得出本次随机的长度(两点之间的长度)，比如 7 
            var distance = Random.Range(min, max);

            // 根据随机确定 X 的符号，Random.Range(0, 2) 只有 0,1 两种可能，整型变量是左闭右开，
            // 如果随机为 1，那么符号为 1，如果随机为 0， 符号为 -1 
            var symbolX = Random.Range(0, 2) == 1 ? 1f : -1f;

            // 然后随机出一个 X 的值，它的范围是最小距离到本次随机出来的长度
            // 如果 X == distance，就代表 Y 轴为0，如果 X == 0, 那么Y轴为 distance
            var randomX = symbolX * Random.Range(0, distance);

            // 确定 Y 的符号，如上
            var symbolY = Random.Range(0, 2) == 1 ? 1f : -1f;

            // 通过开平方得到具体 Y 值，因为 Unity 中 Mathf.Sqrt 只会得出正数，所以要乘以 symbolY
            var posY = symbolY * Mathf.Sqrt(distance * distance - randomX * randomX);

            // 最后整合为一个 Vector2 向量，并返回
            Vector2 pos = new Vector2(randomX, posY);
            return pos;
        }

        /// <summary>
        /// 只随机最终位置，生成位置是一个圆上的所有点
        /// </summary>
        public Vector2 RandomOnlyPos(float min, float max, float distance)
        {
            var symbolX = Random.Range(0, 2) == 1 ? 1f : -1f;
            var randomX = symbolX * Random.Range(0, distance);

            var symbolY = Random.Range(0, 2) == 1 ? 1f : -1f;
            var posY = symbolY * Mathf.Sqrt(distance * distance - randomX * randomX);

            Vector2 pos = new Vector2(randomX, posY);
            return pos;
        }
    }
}