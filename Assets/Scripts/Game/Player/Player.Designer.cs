// Generate Id:06bb81e9-6687-44cb-8f35-a40cb1e7c2ee
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

		public Micosmo.SensorToolkit.RangeSensor2D BodyRange;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorGame.UndeadSurvivorArchitecture.Interface;
	}
}
