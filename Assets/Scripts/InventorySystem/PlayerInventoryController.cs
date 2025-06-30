using UnityEngine;
using System.Collections.Generic;

namespace InventorySystem
{
    public class PlayerInventoryController : MonoBehaviour
    {
        private int armor = 0;
        private int gold = 0;
        private int food = 0;

        private List<SpellType> spells = new List<SpellType>();

        private const int MaxArmor = 5;
        private const int MaxGold = 20;
        private const int MaxSpells = 2;

        public bool AddItem(ItemType type, int amount = 1, SpellType? spell = null)
        {
            switch (type)
            {
                case ItemType.Armor:
                    if (armor >= MaxArmor) return false;
                    armor = Mathf.Min(armor + amount, MaxArmor);
                    break;

                case ItemType.Gold:
                    if (gold >= MaxGold) return false;
                    gold = Mathf.Min(gold + amount, MaxGold);
                    break;

                case ItemType.Food:
                    food += amount;
                    break;

                case ItemType.Spell:
                    if (spells.Count >= MaxSpells || spell == null) return false;
                    spells.Add(spell.Value);
                    break;
            }

            return true;
        }

        public bool RemoveItem(ItemType type, int amount = 1, SpellType? spell = null)
        {
            switch (type)
            {
                case ItemType.Armor:
                    armor = Mathf.Max(armor - amount, 0);
                    break;

                case ItemType.Gold:
                    gold = Mathf.Max(gold - amount, 0);
                    break;

                case ItemType.Food:
                    food = Mathf.Max(food - amount, 0);
                    break;

                case ItemType.Spell:
                    if (spell != null && spells.Contains(spell.Value))
                        return spells.Remove(spell.Value);
                    return false;
            }

            return true;
        }

        public int GetItemCount(ItemType type)
        {
            return type switch
            {
                ItemType.Armor => armor,
                ItemType.Gold => gold,
                ItemType.Food => food,
                ItemType.Spell => spells.Count,
                _ => 0
            };
        }

        public List<SpellType> GetAllSpells()
        {
            return new List<SpellType>(spells);
        }
    }

    public enum ItemType
    {
        Armor,
        Gold,
        Food,
        Spell
    }

    public enum SpellType
    {
        Fire,
        Ice,
        Poison,
        HealthPotion
    }
}
