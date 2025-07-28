using System;
using System.Collections.Generic;
using DungeonSystem.RoomActions;
using NUnit.Framework;
using UnityEngine;

namespace DungeonSystem
{
    public abstract class ARoomDataSO : ScriptableObject
    {
        public string RoomName;
        public RoomType roomType;
        public RoomInteractionType interactionType;
        public Sprite roomSprite;
        public string description;
        
        public ARoomActionSO enterAction;
        public ARoomActionSO exitAction;
        public List<ARoomActionSO> loopActions;
        
        public virtual void Initialize()
        {
            // Base initialization logic, if any
        }
        
    }
    
    public enum RoomInteractionType
    {
        DiceBased,     // Requires dice roll (combat, trap, etc.)
        ChoiceBased,   // Choose between options (event, rest)
        ShopBased      // Merchant-type interaction
    }
    
    public enum RoomType
    {
        Monster,
        Boss,
        Treasure,
        Merchant,
        Resting,
        Event,
        Trap
    }
    
    [System.Serializable]
    public struct MonsterData
    {
        public string monsterName;
        public int HP;
        public int Damage;
        public int Armor;
        
        
        //public SpellType availableSpell; // Optional
    }
    
    [System.Serializable]
    public struct RestingData
    {
        public List<RestingItem> availableItems;
    }
    [System.Serializable]
    public struct RestingItem
    {
        
    }
    
    [System.Serializable]
    public struct TreasureData
    {
        public int goldMin;
        public int goldMax;
        public bool containsItem;
    }
    [System.Serializable]
    public struct EventData
    {
        public string description;
        public List<EventOutcome> possibleOutcomes;
    }

    [System.Serializable]
    public struct EventOutcome
    {
        public string resultText;
        public int requiredRoll;
        public int xpReward;
        public int hpLoss;
    }
    [System.Serializable]
    public struct MerchantData
    {
        public List<ShopItemData> itemsForSale;
    }
    
    [Serializable]
    public struct ShopItemData
    {
        private string itemName;
    }
    
    [System.Serializable]
    public struct TrapData
    {
        public int damageOnFail;
        public int xpRewardOnSuccess;
        public int rollThreshold;
    }


}