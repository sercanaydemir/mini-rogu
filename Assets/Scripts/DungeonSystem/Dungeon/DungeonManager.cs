using System;
using UnityEngine;

namespace DungeonSystem
{
    public class DungeonManager : MonoBehaviour
    {
        public static DungeonManager Instance { get; private set; }

        public DungeonProgress Progress { get; private set; }

        public bool ActivateBoss { get; private set; } = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            Progress = new DungeonProgress();
            UpdateBossState();
        }

        private void Update()
        {
            // This can be used for debugging or UI updates
            if (Input.GetKeyDown(KeyCode.A))
            {
                Advance();
            }
        }

        public void Advance()
        {
            Progress.AdvanceArea();
            UpdateBossState();
            Debug.Log($"Advanced: {Progress.GetProgressDisplay()}, Boss Active: {ActivateBoss}");
        }

        public void ResetDungeon()
        {
            Progress.ResetProgress();
            UpdateBossState();
            Debug.Log("Dungeon reset.");
        }

        public string GetCurrentLocation()
        {
            return Progress.GetProgressDisplay();
        }

        private void UpdateBossState()
        {
            ActivateBoss = Progress.IsLastAreaInLevel;
            if (ActivateBoss)
            {
                Debug.Log($"Boss activated for Level {Progress.CurrentLevel}, Area {Progress.CurrentAreaID}");
            }
            else
            {
                Debug.Log($"No boss for Level {Progress.CurrentLevel}, Area {Progress.CurrentAreaID}");
            }
        }
    }
}