using System;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        
        private void Start()
        {
            // Initialize character stats at the start of the game
            stats.Initialize();
            Debug.Log("Character initialized with default stats.");
        }

        private void Update()
        {
            // Example of adding XP when the player presses the space key
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stats.AddXP(1); // Add 1 XP for demonstration
                Debug.Log($"Current XP: {stats.XP}, Current Rank: {stats.Rank}");
            }
        }
    }
}