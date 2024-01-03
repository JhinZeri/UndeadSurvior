using QFramework;
using UnityEngine;

namespace UndeadSurvivorGame
{
    public static class Global
    {
        public static BindableProperty<int> KillNum = new BindableProperty<int>();

        public static Vector3 GetRandomPos(float min, float max)
        {
            var distance = Random.Range(min, max);
            var symbolX = Random.Range(0, 2) == 1 ? 1f : -1f;
            var randomX = symbolX * Random.Range(min, distance);

            var symbolY = Random.Range(0, 2) == 1 ? 1f : -1f;
            var posY = symbolY * Mathf.Sqrt(distance * distance - randomX * randomX);

            Vector3 pos = new Vector3(randomX, posY, 0);
            return pos;
        }
    }
}