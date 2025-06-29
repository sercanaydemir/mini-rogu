namespace DungeonSystem
{
    using UnityEngine;

    public class RoomController : MonoBehaviour
    {
        public RoomDataSO roomData;

        public void InitializeRoom(Vector3 pos)
        {
            transform.position = pos;
            //Debug.Log($"Room '{roomData.RoomName}' initialized!");
        }
    }
}

