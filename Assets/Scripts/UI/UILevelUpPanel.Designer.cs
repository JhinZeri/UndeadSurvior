using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame.UI
{
	// Generate Id:37f748df-1bb6-4469-a93f-c776b9b0641a
	public partial class UILevelUpPanel
	{
		public const string Name = "UILevelUpPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnUpgradeShovel;
		
		private UILevelUpPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnUpgradeShovel = null;
			
			mData = null;
		}
		
		public UILevelUpPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UILevelUpPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UILevelUpPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
