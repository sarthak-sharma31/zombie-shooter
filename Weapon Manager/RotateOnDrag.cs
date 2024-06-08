using UnityEngine;
using UnityEngine.EventSystems;

public class RotateOnDrag : MonoBehaviour, IDragHandler
{
    public float rotationSpeed = 0.2f;
    public Transform model;

    public void OnDrag(PointerEventData eventData)
    {
        float rotX = eventData.delta.x * rotationSpeed;
        float rotY = eventData.delta.y * rotationSpeed;

        model.Rotate(Vector3.up, -rotX, Space.World);
        model.Rotate(Vector3.right, rotY, Space.World);
    }
}
