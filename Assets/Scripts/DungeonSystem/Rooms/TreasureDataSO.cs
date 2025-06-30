using UnityEngine;

namespace DungeonSystem
{
    [CreateAssetMenu(fileName = "Treasure Room", menuName = "Dungeon System / Rooms / Treasure Room", order = 0)]
    public class TreasureDataSO : ARoomDataSO
    {
        public TreasureData treasureData;
    }
}