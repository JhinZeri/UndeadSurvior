using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace UndeadSurvivorGame.UI
{
    public class UIGamePanelData : UIPanelData
    {
    }

    public partial class UIGamePanel : UIPanel
    {
        protected override void OnInit(IUIData uiData = null)
        {
            mData = uiData as UIGamePanelData ?? new UIGamePanelData();
            // please add init code here

            Player.Instance.PlayerRuntimeData.CurHealth.RegisterWithInitValue(health =>
            {
                HealthText.text = "生命值: " + $"({health}/{PlayerData.MaxHealth})";
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.GlobalTime.RegisterWithInitValue(time =>
            {
                var minute = Mathf.FloorToInt(time / 60);
                var second = time % 60;
                GlobalTimeText.text = "时间: " + $"{minute:00}:{second:00}";

                if (time >= 20f)
                {
                    Global.GameLevel.Value = 2;
                }

                if (time >= 40f)
                {
                    Global.GameLevel.Value = 3;
                }
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.GameLevel.RegisterWithInitValue(lv => { GameLevelText.text = "关卡等级: " + lv; })
                .UnRegisterWhenGameObjectDestroyed(this);

            Global.EnemyNum.RegisterWithInitValue(num => { EnemyText.text = "敌人数量: " + num; })
                .UnRegisterWhenGameObjectDestroyed(this);

            Global.KillNum.RegisterWithInitValue(num => { KillText.text = "杀敌数: " + num; })
                .UnRegisterWhenGameObjectDestroyed(this);

            Global.PlayerLevel.RegisterWithInitValue(lv => { PlayerLevelText.text = "玩家等级: " + lv; })
                .UnRegisterWhenGameObjectDestroyed(this);

            Global.Exp.RegisterWithInitValue(exp =>
            {
                if (exp >= 5 * Global.PlayerLevel.Value)
                {
                    Global.PlayerLevel.Value += 1;
                    Global.Exp.Value = 0;
                    Time.timeScale = 0;
                    UIKit.OpenPanel<UILevelUpPanel>();
                    Hide();
                }

                ExpText.text = "经验值: " + exp;
            }).UnRegisterWhenGameObjectDestroyed(this);
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
        }
    }
}