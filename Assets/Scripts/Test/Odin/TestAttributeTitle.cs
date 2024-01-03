using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


namespace TestCodes.Odin
{
    public class TestAttributeTitle : MonoBehaviour
    {
        // QFramework 生成的脚本和 Title 冲突
        [Title("Test Title Attribute")] public int TestInt;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}