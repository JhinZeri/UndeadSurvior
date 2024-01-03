using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame
{
    public class UIGameStartPanelData : UIPanelData
    {
    }

    public partial class UIGameStartPanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIGameStartPanelData ?? new UIGameStartPanelData();
            // please add init code here

            Time.timeScale = 0;
            BtnStart.onClick.AddListener((() =>
            {
                Time.timeScale = 1f;
                UIKit.OpenPanel<UIGamePanel>();
                CloseSelf();
            }));
        }

        protected override void OnOpen(IUIData uiData = null)
        {
        }

        protected override void OnShow()
        {
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
            BtnStart.onClick.RemoveAllListeners();
        }
    }
}