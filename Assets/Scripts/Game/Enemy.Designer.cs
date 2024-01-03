// Generate Id:eac8518f-8259-4ca9-af61-2eeb98e31f55
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class Enemy : QFramework.IController
	{

		public SpriteRenderer Sprite;

		public Collider2D Collider;

		public UnityEngine.Animator Animator;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorGame.UndeadSurvivorArchitecture.Interface;
	}
}
