using System;
using UnityEngine;
using QFramework;
using Sirenix.OdinInspector;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace UndeadSurvivorGame
{
    public partial class Player : ViewController
    {
        public static Player Instance { get; private set; }

        [Serializable]
        public struct PlayerData
        {
            public float Speed;
        }

        [Searchable] public PlayerData PlayerRuntimeData;
        [Header("运行时数据")] public Vector2 MoveVector2;

        private void Awake()
        {
            Instance = this;

            PlayerRuntimeData = new PlayerData();


            if (PlayerRuntimeData.Speed <= 0)
            {
                PlayerRuntimeData.Speed = 3f;
            }
        }

        void Start()
        {
            // Code Here
        }

        private void FixedUpdate()
        {
            SelfRigid.velocity = MoveVector2 * PlayerRuntimeData.Speed;
        }

        private void Update()
        {
            MoveInput();
            SpriteDirection();
        }

        private void SpriteDirection()
        {
            if (MoveVector2.x > 0)
            {
                Sprite.flipX = false;
            }

            if (MoveVector2.x < 0)
            {
                Sprite.flipX = true;
            }
        }

        private Vector2 MoveInput()
        {
            var xInput = Input.GetAxisRaw("Horizontal");
            var yInput = Input.GetAxisRaw("Vertical");

            MoveVector2 = new Vector2(xInput, yInput);
            return MoveVector2;
        }
    }
}