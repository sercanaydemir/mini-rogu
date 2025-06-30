using System;
using Character;
using GameFlow;
using InventorySystem;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        [SerializeField] private PlayerInventoryController inventory;

        private void Start()
        {
            InitializeBasedOnDifficulty();
        }

        private void InitializeBasedOnDifficulty()
        {
            stats.XP = 0;
            stats.Rank = 1;

            var difficulty = DifficultyManager.Instance.GetCurrentDifficulty();

            int hp = 0, armor = 0, gold = 0, food = 0;

            switch (difficulty)
            {
                case DifficultyLevel.Casual:
                    armor = 1; hp = 5; gold = 5; food = 6;
                    break;
                case DifficultyLevel.Normal:
                    armor = 0; hp = 5; gold = 3; food = 6;
                    break;
                case DifficultyLevel.Hard:
                    armor = 0; hp = 4; gold = 2; food = 5;
                    break;
                case DifficultyLevel.Impossible:
                    armor = 0; hp = 3; gold = 1; food = 3;
                    break;
            }

            stats.HP = hp;
            stats.Armor = armor;
            stats.Gold = gold;
            stats.Food = food;
            stats.MaxHP = 20; // Assuming MaxHP is constant for all difficulties

            inventory.AddItem(ItemType.Armor, armor);
            inventory.AddItem(ItemType.Gold, gold);
            inventory.AddItem(ItemType.Food, food);

            Debug.Log($"Initialized stats and inventory for difficulty: {difficulty}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stats.AddXP(1);
                Debug.Log($"Current XP: {stats.XP}, Current Rank: {stats.Rank}");
            }
        }
    }
}