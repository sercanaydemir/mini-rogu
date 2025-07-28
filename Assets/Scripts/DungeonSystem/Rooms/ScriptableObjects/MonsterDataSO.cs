using UnityEngine;

namespace DungeonSystem
{    
    [CreateAssetMenu(fileName = "Monster Room", menuName = "Dungeon System / Rooms / Monster Room", order = 0)]
    public class MonsterDataSO : ARoomDataSO
    {
        public MonsterData monsterData;
    }
}