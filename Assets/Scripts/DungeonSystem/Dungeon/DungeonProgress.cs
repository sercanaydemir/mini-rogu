using System;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonSystem
{
    [Serializable]
    public class DungeonProgress
    {
        // Represents the structure of the dungeon (Level -> Area IDs)
        private Dictionary<int, List<int>> dungeonStructure = new Dictionary<int, List<int>>()
        {
            { 1, new List<int> { 1, 2 } },             
            { 2, new List<int> { 3, 4 } },          
            { 3, new List<int> { 5, 6, 7 } },           
            { 4, new List<int> { 8, 9, 10 } },          
            { 5, new List<int> { 11, 12, 13, 14 } }     
        };

        public int CurrentLevel { get; private set; } = 1;
        public int CurrentAreaIndex { get; private set; } = 0;

        public int CurrentAreaID => dungeonStructure[CurrentLevel][CurrentAreaIndex];

        public bool IsLastAreaInLevel => CurrentAreaIndex >= dungeonStructure[CurrentLevel].Count - 1;
        public bool IsLastLevel => CurrentLevel >= 5;

        /// <summary>
        /// Advances to the next area in the current level.
        /// If the area is the last one, moves to the next level and resets area index.
        /// </summary>
        public void AdvanceArea()
        {
            if (!IsLastAreaInLevel)
            {
                CurrentAreaIndex++;
            }
            else if (!IsLastLevel)
            {
                AdvanceLevel();
            }
            else
            {
                Debug.Log("Dungeon completed!");
            }
        }

        /// <summary>
        /// Advances to the next level and resets area index.
        /// </summary>
        private void AdvanceLevel()
        {
            if (!IsLastLevel)
            {
                CurrentLevel++;
                CurrentAreaIndex = 0;
                Debug.Log($"Advanced to Level {CurrentLevel}, Area {CurrentAreaID}");
            }
        }

        /// <summary>
        /// Resets dungeon progress to level 1 area 1.
        /// </summary>
        public void ResetProgress()
        {
            CurrentLevel = 1;
            CurrentAreaIndex = 0;
        }

        /// <summary>
        /// Returns a string like "Level 2 - Area 4"
        /// </summary>
        public string GetProgressDisplay()
        {
            return $"Level {CurrentLevel} - Area {CurrentAreaID}";
        }
    }
}
