// Generate Id:59e9c7c1-53b0-48ab-ac00-88b4ac53b9f2
using UnityEngine;

namespace UndeadSurvivorGame
{
	public partial class WeaponManager : QFramework.IController
	{

		public UndeadSurvivorGame.WeaponShovel WeaponShovel;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>UndeadSurvivorArchitecture.Interface;
	}
}
