using System;
using UnityEngine;
using QFramework;
using UndeadSurvivorGame.UI;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace UndeadSurvivorGame
{
    [Serializable]
    public class PlayerData
    {
        public static float MaxHealth = 10f;
        public BindableProperty<float> CurHealth = new BindableProperty<float>(MaxHealth);
        public float Speed;
    }

    public partial class Player : ViewController
    {
        
        public static Player Instance { get; private set; }

        public PlayerData PlayerRuntimeData;

        [Header("Runtime")] public Vector2 MoveVector2;


        // Animator
        private static readonly int Speed = Animator.StringToHash("speed");

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
            UIRoot.Instance.SetResolution(1920, 1080, 0.5f);
            UIKit.OpenPanel<UIGameStartPanel>();
        }

        private void FixedUpdate()
        {
            SelfRigid.velocity = MoveVector2 * PlayerRuntimeData.Speed;
        }

        private void Update()
        {
            MoveInput();
            SpriteDirection();
            SensorPulse();
        }

        private void LateUpdate()
        {
            UpdateAnimator();
        }


        private void SensorPulse()
        {
            BodyRange.Pulse();
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

        private void MoveInput()
        {
            var xInput = Input.GetAxisRaw("Horizontal");
            var yInput = Input.GetAxisRaw("Vertical");

            MoveVector2 = new Vector2(xInput, yInput);
        }


        private void UpdateAnimator()
        {
            SelfAnimator.SetFloat(Speed, MoveVector2.magnitude);
        }

        public void GetHurt(float damage)
        {
            PlayerRuntimeData.CurHealth.Value -= damage;
        }
    }
}