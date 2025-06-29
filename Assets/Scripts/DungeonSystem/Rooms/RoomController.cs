namespace DungeonSystem
{
    using UnityEngine;

    public class RoomController : MonoBehaviour
    {
        public RoomDataSO roomData;
        private Vector3 initialPosition;
        public void InitializeRoom(Vector3 pos)
        {
            transform.position = pos;
            initialPosition = pos;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //Debug.Log($"Room '{roomData.RoomName}' initialized!");
        }
        
        public void ResetRoomPosition()
        {
            transform.position = initialPosition;
            //Debug.Log($"Room '{roomData.RoomName}' reset to initial position.");
        }
        
        
    }
}

