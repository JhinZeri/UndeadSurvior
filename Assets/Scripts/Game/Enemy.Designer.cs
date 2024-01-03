// Generate Id:5bbb2dd6-b20a-461a-af53-a6897f873257
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class Enemy : QFramework.IController
	{

		public SpriteRenderer Sprite;

		public Collider2D Collider;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorArchitecture.Interface;
	}
}
