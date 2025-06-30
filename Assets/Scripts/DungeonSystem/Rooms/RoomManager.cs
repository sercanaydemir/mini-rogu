using UnityEngine;

namespace DungeonSystem
{
    public class RoomManager : MonoBehaviour
    {
        
        [SerializeField] private ARoomDataSO[] roomDataArray;
        [SerializeField] private ARoomDataSO bossRoomData;
        
        public ARoomDataSO[] GetRoomsRandom()
        {
            return ArrayShuffler.GetShuffledArray(roomDataArray);
        }
        
        public ARoomDataSO GetBossRoom()
        {
            return bossRoomData;
        }
    }
}