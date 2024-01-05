// Generate Id:8c98c4b5-1d0f-482b-a05e-ac4df7d37320
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class WeaponManager : QFramework.IController
	{

		public UndeadSurvivorGame.WeaponShovel WeaponShovel;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorGame.UndeadSurvivorArchitecture.Interface;
	}
}
