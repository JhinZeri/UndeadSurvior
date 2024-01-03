// Generate Id:b6f1e5ff-b6b9-47b6-9231-bd77c5f51d01
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

		public UnityEngine.Animator SelfAnim;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorArchitecture.Interface;
	}
}
