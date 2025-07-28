using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DungeonSystem.RoomActions
{
    public abstract class ARoomActionSO : ScriptableObject
    {
        public abstract UniTask ExecuteAsync(RoomController controller);
        public abstract bool IsActionDone();
        public abstract void ResetAction();
    }
}