// Generate Id:6779b27b-6523-4bbe-838d-268ab16b221a
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class Enemy : QFramework.IController
	{

		public SpriteRenderer Sprite;

		public Collider2D Collider;

		public Micosmo.SensorToolkit.RangeSensor2D BodySensor;

		public UnityEngine.Animator Animator;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorGame.UndeadSurvivorArchitecture.Interface;
	}
}
