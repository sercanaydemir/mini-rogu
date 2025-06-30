using UnityEngine;

namespace GameFlow
{
    public class DifficultyManager : MonoBehaviour
    {
        [SerializeField] private DifficultyLevel currentDifficulty = DifficultyLevel.Casual;

        public static DifficultyManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public DifficultyLevel GetCurrentDifficulty()
        {
            return currentDifficulty;
        }

        public void SetDifficulty(DifficultyLevel newDifficulty)
        {
            currentDifficulty = newDifficulty;
            Debug.Log($"Difficulty set to: {currentDifficulty}");
        }
    }
    
    public enum DifficultyLevel
    {
        Casual,
        Normal,
        Hard,
        Impossible
    }
}