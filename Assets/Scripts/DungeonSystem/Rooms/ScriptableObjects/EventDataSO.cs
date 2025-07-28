using UnityEngine;

namespace DungeonSystem
{
    [CreateAssetMenu(fileName = "Event Room", menuName = "Dungeon System / Rooms / Event Room", order = 0)]
    public class EventDataSO : ARoomDataSO
    {
        public EventData eventData;
    }
}