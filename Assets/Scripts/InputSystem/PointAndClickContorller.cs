using DungeonSystem;

namespace InputSystem
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class PointAndClickController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask clickableLayer;
        private RoomController _selectedRoom;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.LogError("Mouse clicked, casting ray...");
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer) && _selectedRoom == null)
                {
                    Debug.Log($"Hit object: {hit.collider.name}");
                    RoomController roomController = hit.collider.GetComponent<RoomController>();
                    
                    if (roomController != null)
                    {
                        // Handle room click logic here
                        Debug.Log($"Clicked on room!");
                        _selectedRoom = roomController;
                        roomController.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f; // Move the room in front of the camera
                        // roomController.transform.eulerAngles = new Vector3(-15,0,0);

                        // You can add more logic to interact with the room
                    }
                    else
                    {
                        Debug.Log("Clicked on a non-room object.");
                    }
                    // Handle click logic here
                }
                else if(_selectedRoom != null)
                {
                    // If a room was previously selected, reset its position
                    Debug.Log("Resetting room position.");
                    _selectedRoom.ResetRoomPosition();
                    _selectedRoom = null;
                }
                else
                {
                    Debug.Log("No clickable object hit.");
                }
            }
        }
    }
}