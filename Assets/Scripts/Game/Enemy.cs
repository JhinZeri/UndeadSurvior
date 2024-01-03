using System;
using UnityEngine;
using QFramework;

namespace UndeadSurvivorGame
{
    public partial class Enemy : ViewController
    {
        public float CurrentSpeed;

        private Vector2 mDirVector2;

        private void Update()
        {
            if (Player.Instance)
            {
                mDirVector2 = (Player.Instance.transform.position - transform.position).normalized;

                transform.Translate(mDirVector2 * (CurrentSpeed * Time.deltaTime));
            }

            SpriteDirection();
        }

        public void UnderAttack()
        {
            ActionKit.Sequence().Callback(() => Sprite.color = Color.red)
                .Delay(0.3f, () =>
                {
                    Sprite.color = Color.white;
                    Debug.Log("变白色");
                }).Start(this);
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