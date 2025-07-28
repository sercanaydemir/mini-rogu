using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DungeonSystem.RoomActions
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class ShowUIAction : ARoomActionSO
    {
        public override UniTask ExecuteAsync(RoomController controller)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsActionDone()
        {
            throw new System.NotImplementedException();
        }

        public override void ResetAction()
        {
            throw new System.NotImplementedException();
        }
    }
}