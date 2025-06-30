using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DungeonSystem
{
    public class DungeonGenerator : MonoBehaviour
    {
        [SerializeField] private RoomManager roomManager;
        [SerializeField] private DungeonPool pool;
        [SerializeField] private DungeonScheme scheme;
        [SerializeField] private Transform areaStartPoint;
        [SerializeField] private float horizontalRoomSpacing = 5f;
        [SerializeField] private float verticalRoomSpacing = 10f;
        
        [SerializeField] private List<RoomController> rooms;
        private void Start()
        {
            GenerateDungeon();
        }

        private void GenerateDungeon()
        {
            if (roomManager == null)
            {
                Debug.LogError("RoomManager is not assigned in DungeonGenerator.");
                return;
            }
            
            if (pool == null)
            {
                Debug.LogError("DungeonPool is not assigned in DungeonGenerator.");
                return;
            }
            
            var roomData = roomManager.GetRoomsRandom();
            
            for (int i = 0; i < scheme.Scheme.Length; i++)
            {
                int rowCount = scheme.Scheme[i];

                CreateRooms(rowCount, i,roomData[i]);
            }
        }

        void CreateRooms(int rowCount,int lineOrder,ARoomDataSO roomDataSo)
        {
            int mod = rowCount % 2;

            if (mod == 1)
            {
                int index = rowCount / 2;

                if (index <= 1)
                {
                    RoomController rc = pool.GetRoom();
                    rc.InitializeRoom(roomDataSo,CalculateDungeonPosition(0,lineOrder));
                }
                
            }
            else
            {
                float half = rowCount / 2f;
                Vector3 startPos = areaStartPoint.position + new Vector3(-(half - 0.5f) * horizontalRoomSpacing, 0, lineOrder * verticalRoomSpacing);

                for (int i = 0; i < rowCount; i++)
                {
                    RoomController rc = pool.GetRoom();
                    rc.InitializeRoom(roomDataSo,startPos + new Vector3(i * horizontalRoomSpacing, 0, 0));
                }

            }
        }

        Vector3 CalculateDungeonPosition(int xOffset,int zOffset)
        {
            return areaStartPoint.position +
                   new Vector3(xOffset * horizontalRoomSpacing,0, zOffset * verticalRoomSpacing);
        }
        
        
    }
    
    [Serializable]
    public struct DungeonScheme
    {
        public int[] Scheme;
    }
    
    
}

