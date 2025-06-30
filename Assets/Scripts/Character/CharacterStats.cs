using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class CharacterStats
    {
        // Core Stats
        public int HP;
        public int MaxHP;

        public int Armor;
        public int Gold;
        public int Food;

        // Experience and Leveling
        public int XP;
        public int Rank; // Starts from 1

        // XP thresholds for each Rank level
        private static readonly int[] XPThresholds = { 0, 5, 10, 17, 25 };

        // Initializes default character stats at the beginning of the game
        public void Initialize()
        {
            HP = MaxHP = 10;
            Armor = 0;
            Gold = 0;
            Food = 3;
            XP = 0;
            Rank = 1;
        }

        // Adds XP and checks for rank upgrade
        public void AddXP(int amount)
        {
            XP += amount;
            UpdateRank();
            Debug.Log($"XP increased by {amount}. Total XP: {XP}, New Rank: {Rank}");
        }

        // Updates character's rank based on XP
        private void UpdateRank()
        {
            for (int i = XPThresholds.Length - 1; i >= 0; i--)
            {
                if (XP >= XPThresholds[i])
                {
                    Rank = i + 1;
                    return;
                }
            }

            Rank = 1;
        }

        // Returns the number of dice the character can roll based on current rank
        public int GetDiceCount()
        {
            return Mathf.Min(4, Rank); // Max 3 dice
        }

        // Consumes 1 food. If no food left, applies starvation penalty.
        public bool SpendFood()
        {
            if (Food > 0)
            {
                Food--;
                Debug.Log("1 Food spent.");
                return true;
            }

            HP -= 2;
            Debug.LogWarning("No food left! HP decreased by 2 due to starvation.");
            return false;
        }

        // Heals the character for the given amount, but not above max HP
        public void Heal(int amount)
        {
            HP = Mathf.Min(HP + amount, MaxHP);
            Debug.Log($"Healed by {amount}. Current HP: {HP}");
        }

        // Applies damage after reducing it by current armor value
        public void TakeDamage(int damage)
        {
            int damageAfterArmor = Mathf.Max(0, damage - Armor);
            HP -= damageAfterArmor;

            // Reduce armor if damage was higher
            Armor = Mathf.Max(0, Armor - damage);

            Debug.Log($"Took {damageAfterArmor} damage after armor. Remaining HP: {HP}, Armor: {Armor}");
        }
    }
}