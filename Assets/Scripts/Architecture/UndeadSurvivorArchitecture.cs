using QFramework;
using UndeadSurvivorGame.Utility;

namespace UndeadSurvivorGame
{
    public class UndeadSurvivorArchitecture : Architecture<UndeadSurvivorArchitecture>
    {
        protected override void Init()
        {
            RegisterUtility(new RandomCalculateUtility());
        }
    }
}