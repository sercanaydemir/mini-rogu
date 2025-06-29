using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        
        private void Start()
        {
            // Initialize character stats at the start of the game
            stats.Initialize();
            Debug.Log("Character initialized with default stats.");
        }
        
    }
}