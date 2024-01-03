// Generate Id:bb1d3ed9-0f80-4042-b468-5039b61fa98a
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class Player : QFramework.IController
	{

		public UnityEngine.SpriteRenderer Sprite;

		public UnityEngine.CapsuleCollider2D BodyCollider;

		public Transform Sensor;

		public WeaponManager Weapon;

		public UnityEngine.Rigidbody2D SelfRigid;

		public UnityEngine.Animator SelfAnimator;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorGame.UndeadSurvivorArchitecture.Interface;
	}
}
