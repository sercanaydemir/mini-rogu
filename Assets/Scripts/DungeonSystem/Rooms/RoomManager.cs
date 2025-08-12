using UnityEngine;

namespace DungeonSystem
{
    public class RoomManager : MonoBehaviour
    {
        
        [SerializeField] private ARoomDataSO[] roomDataArray;
        [SerializeField] private ARoomDataSO bossRoomData;
        
        public ARoomDataSO[] GetRoomsRandom()
        {
            
            var roomsData = ArrayShuffler.GetShuffledArray(roomDataArray);
            
            return roomsData;
        }
        
        public ARoomDataSO GetBossRoom()
        {
            return bossRoomData;
        }
    }
}