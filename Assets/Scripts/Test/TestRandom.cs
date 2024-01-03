using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestCodes
{
    public class TestRandom : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var randomPos = RandomPos(5f, 10f);
                Debug.Log("范围是5-10,随机出来的向量为: " + randomPos);
            }
        }

        public Vector2 RandomPos(float min, float max)
        {
            var distance = Random.Range(min, max);
            var symbolX = Random.Range(0, 2) == 1 ? 1f : -1f;
            var randomX = symbolX * Random.Range(min, distance);

            var symbolY = Random.Range(0, 2) == 1 ? 1f : -1f;
            var posY = symbolY * Mathf.Sqrt(distance * distance - randomX * randomX);

            Vector2 pos = new Vector2(randomX, posY);
            return pos;
        }
    }
}