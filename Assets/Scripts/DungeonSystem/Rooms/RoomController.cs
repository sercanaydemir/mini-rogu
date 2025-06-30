
using UnityEngine.Serialization;

namespace DungeonSystem
{
    using UnityEngine;

    public class RoomController : MonoBehaviour
    {
        [FormerlySerializedAs("roomData")] public ARoomDataSO aRoomData;
        private Vector3 initialPosition;

        [Header("Card Visuals")] 
        [SerializeField] private SpriteRenderer spriteRenderer;
        ARoomDataSO roomDataSo;
        
        public void InitializeRoom(ARoomDataSO roomDataSo,Vector3 pos)
        {
            this.roomDataSo = roomDataSo;
            transform.position = pos;
            initialPosition = pos;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //Debug.Log($"Room '{roomData.RoomName}' initialized!");
            spriteRenderer.sprite = roomDataSo.roomSprite;
        }
        
        public void ResetRoomPosition()
        {
            transform.position = initialPosition;
            //Debug.Log($"Room '{roomData.RoomName}' reset to initial position.");
        }
        
        
    }
}

