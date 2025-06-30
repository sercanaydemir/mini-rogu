using System;
using Character;
using UnityEngine;

namespace DiceSystem
{
    public class DiceManager : MonoBehaviour
    {
        [SerializeField] private Dice[] allDices;

        private int currentDiceCount = 1;

        private void OnEnable()
        {
            CharacterStats.OnCharacterLevelUp += UnlockNewDice;
        }
        
        private void OnDisable()
        {
            CharacterStats.OnCharacterLevelUp -= UnlockNewDice;
        }

        private void Start()
        {
            InitializeDices();
        }
        
        
        private void InitializeDices()
        {
            foreach (var dice in allDices)
            {
                dice.gameObject.SetActive(false);
            }

            if (currentDiceCount > allDices.Length)
            {
                currentDiceCount = allDices.Length;
            }

            for (int i = 0; i < currentDiceCount; i++)
            {
                allDices[i].gameObject.SetActive(true);
            }
        }
        
        private void UnlockNewDice(int rank)
        {
            if (currentDiceCount <= allDices.Length)
            {
                currentDiceCount++;
                if (currentDiceCount <= allDices.Length)
                {
                    allDices[currentDiceCount - 1].gameObject.SetActive(true);
                    Debug.Log($"New dice unlocked: {allDices[currentDiceCount - 1].name}");
                }
                else
                {
                    Debug.Log("All dice have been unlocked.");
                }
            }
        }

    }
}