using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame.UI
{
	// Generate Id:067be821-68a3-496a-a3ed-7b4c0b4b0da8
	public partial class UIGameStartPanel
	{
		public const string Name = "UIGameStartPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button BtnStart;
		
		private UIGameStartPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BtnStart = null;
			
			mData = null;
		}
		
		public UIGameStartPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIGameStartPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIGameStartPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
