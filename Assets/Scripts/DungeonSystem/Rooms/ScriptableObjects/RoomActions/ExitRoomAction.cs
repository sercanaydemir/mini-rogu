using Cysharp.Threading.Tasks;
using DungeonSystem.RoomActions;
using UnityEngine;

namespace DungeonSystem.Rooms.ScriptableObjects.RoomActions
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class ExitRoomAction : ARoomActionSO
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