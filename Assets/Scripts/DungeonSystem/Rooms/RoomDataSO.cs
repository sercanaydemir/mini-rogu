using UnityEngine;

namespace DungeonSystem
{
    [CreateAssetMenu(fileName = "Room", menuName = "Dungeon System / Rooms / Rooms", order = 0)]
    public class RoomDataSO : ScriptableObject
    {
        public string RoomName;
        
    }
}