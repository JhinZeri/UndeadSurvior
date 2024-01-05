using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestCodes
{
    public class TestRotationParent : MonoBehaviour
    {
        public GameObject Prefab;

        public int Number;

        public List<GameObject> ListShovel = new List<GameObject>();

        private void Start()
        {
            var obj = Lean.Pool.LeanPool.Spawn(Prefab, new Vector3(0, 1.5f, 0), Quaternion.identity, transform);
            ListShovel.Add(obj);
        }

        void Update()
        {
            transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        }

        // 第一步，回收进对象池
        public void GenerateStart()
        {
            foreach (var shovel in ListShovel)
            {
                Lean.Pool.LeanPool.Despawn(shovel);
            }
        }

        // 第二步，根据数量生成
        public void GenerateSecond()
        {
            // 列表是存储的引用，所以直接添加会重复引用同一个物体，可以先清空一次，或者在添加时做判断检测
            ListShovel.Clear();
            for (int index = 0; index < Number; index++)
            {
                var obj = Lean.Pool.LeanPool.Spawn(Prefab, transform);
                ListShovel.Add(obj);
            }
        }

        // 第三步，调整旋转角度
        public void GenerateThird()
        {
            var angle = 360 / Number;
            for (int index = 0; index < ListShovel.Count; index++)
            {
                ListShovel[index].transform.Rotate(Vector3.forward * angle * index);
            }
        }

        // 第四步，调整位置
        public void GenerateForth()
        {
            var angle = 360 / Number;
            for (int index = 0; index < ListShovel.Count; index++)
            {
                ListShovel[index].transform.Translate(ListShovel[index].transform.up * 1.5f, Space.World);
            }
        }

        // 整合之前步骤
        public void GenerateConclusion()
        {
            foreach (var shovel in ListShovel)
            {
                Lean.Pool.LeanPool.Despawn(shovel);
            }

            // 列表是存储的引用，所以直接添加会重复引用同一个物体，可以先清空一次，或者在添加时做判断检测
            ListShovel.Clear();
            for (int index = 0; index < Number; index++)
            {
                var obj = Lean.Pool.LeanPool.Spawn(Prefab, transform);
                ListShovel.Add(obj);
            }

            var angle = 360 / Number;
            for (int index = 0; index < ListShovel.Count; index++)
            {
                ListShovel[index].transform.Rotate(Vector3.forward * angle * index);
                ListShovel[index].transform.Translate(ListShovel[index].transform.up * 1.5f, Space.World);
            }
        }
    }
}