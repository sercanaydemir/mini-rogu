using System;
using System.Collections.Generic;
using System.Xml.Schema;
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
            if (roomManager == null) { Debug.LogError("RoomManager is not assigned in DungeonGenerator."); return; }
            if (pool == null)        { Debug.LogError("DungeonPool is not assigned in DungeonGenerator."); return; }

            var roomData = roomManager.GetRoomsRandom();

            // (Opsiyonel) toplam ihtiyacı kontrol et
            int totalNeeded = 0;
            for (int t = 0; t < scheme.Scheme.Length; t++) totalNeeded += scheme.Scheme[t];
            if (roomData.Length < totalNeeded)
            {
                Debug.LogError($"Not enough room data. Needed: {totalNeeded}, Have: {roomData.Length}");
                return;
            }

            int x = 0;
            for (int row = 0; row < scheme.Scheme.Length; row++)
            {
                int rowCount = scheme.Scheme[row];

                for (int col = 0; col < rowCount; col++)
                {
                    if (x >= roomData.Length)
                    {
                        Debug.LogError("Not enough room data available for the scheme. Stopping generation.");
                        return;
                    }

                    var data = roomData[x];
                    Debug.LogError($"Creating room {x} at position ({row}, {col}) - {data.RoomName}");

                    CreateRoom(rowCount, row, col, data); // <<< TEK ODA
                    x++;
                }
            }
        }

        void CreateRoom(int rowCount, int lineOrder, int colIndex, ARoomDataSO data)
        {
            // Row başlangıç X ofsetini hem tek hem çift sayılar için hesapla
            float offsetX = (rowCount % 2 == 0)
                ? -(rowCount / 2f - 0.5f) * horizontalRoomSpacing
                : -Mathf.Floor(rowCount / 2f) * horizontalRoomSpacing;

            Vector3 startPos = areaStartPoint.position + new Vector3(offsetX, 0, lineOrder * verticalRoomSpacing);
            Vector3 pos = startPos + new Vector3(colIndex * horizontalRoomSpacing, 0, 0);

            RoomController rc = pool.GetRoom();
            rc.InitializeRoom(data, pos);
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
        
        public int GetSchemeCardCount()
        {
            int count = 0;
            foreach (var item in Scheme)
            {
                count += item;
            }
            return count;
        }
    }
    
    
}

