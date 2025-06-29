using System;
using UnityEngine;
using UnityEngine.Pool;

namespace DungeonSystem
{
    public class DungeonPool : MonoBehaviour
    {
        [SerializeField] private RoomController roomPrefab;
        private ObjectPool<RoomController> roomPool;

        private void Awake()
        {
            roomPool = new ObjectPool<RoomController>(
                CreateRoom,
                OnGetRoom,
                OnReleaseRoom,
                OnDestroyRoom,
                false, // Automatically expand the pool
                10,    // Initial capacity
                20     // Maximum capacity
            );
        }
        
        public RoomController GetRoom()
        {
            RoomController room = roomPool.Get();
            //Debug.Log($"Room '{room.roomData.RoomName}' retrieved from pool.");
            return room;
        }

        private void OnDestroyRoom(RoomController obj)
        {
            Destroy(obj.gameObject); // Clean up the room when it's destroyed
            //Debug.Log($"Room '{obj.roomData.RoomName}' destroyed.");
        }

        private void OnReleaseRoom(RoomController obj)
        {
            obj.gameObject.SetActive(false); // Deactivate the room when releasing it back to the pool
            //Debug.Log($"Room '{obj.roomData.RoomName}' returned to pool.");
        }

        private void OnGetRoom(RoomController obj)
        {
            obj.gameObject.SetActive(true); // Activate the room when getting it from the pool
            //Debug.Log($"Room '{obj.roomData.RoomName}' retrieved from pool.");
        }

        private RoomController CreateRoom()
        {
            RoomController room = Instantiate(roomPrefab);
            room.gameObject.SetActive(false); // Start inactive
            return room;
        }
    }
}