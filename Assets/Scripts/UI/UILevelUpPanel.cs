using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame.UI
{
    public class UILevelUpPanelData : UIPanelData
    {
    }

    public partial class UILevelUpPanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UILevelUpPanelData ?? new UILevelUpPanelData();
            // please add init code here

            BtnUpgradeShovel.onClick.AddListener(() =>
            {
                var shovel = Player.Instance.GetComponentInChildren<WeaponShovel>();
                shovel.Upgrade();
                Hide();
                UIKit.OpenPanel<UIGamePanel>();
                Time.timeScale = 1f;
            });
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
            BtnUpgradeShovel.onClick.RemoveAllListeners();
        }
    }
}