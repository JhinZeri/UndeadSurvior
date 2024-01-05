using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame.UI
{
	// Generate Id:3948e2dd-0fcb-411b-bc73-86d95c626245
	public partial class UIGamePanel
	{
		public const string Name = "UIGamePanel";
		
		[SerializeField]
		public UnityEngine.UI.Text KillText;
		[SerializeField]
		public UnityEngine.UI.Text GlobalTimeText;
		[SerializeField]
		public UnityEngine.UI.Text GameLevelText;
		[SerializeField]
		public UnityEngine.UI.Text EnemyText;
		[SerializeField]
		public UnityEngine.UI.Text HealthText;
		[SerializeField]
		public UnityEngine.UI.Text ExpText;
		[SerializeField]
		public UnityEngine.UI.Text PlayerLevelText;
		
		private UIGamePanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			KillText = null;
			GlobalTimeText = null;
			GameLevelText = null;
			EnemyText = null;
			HealthText = null;
			ExpText = null;
			PlayerLevelText = null;
			
			mData = null;
		}
		
		public UIGamePanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGamePanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGamePanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
