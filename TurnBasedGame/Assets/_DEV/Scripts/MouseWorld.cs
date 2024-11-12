using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    // Singleton instance to allow easy access to the MouseWorld class
    private static MouseWorld instance;

    // Layer mask to specify which layer to use for raycasting the mouse position
    [SerializeField] private LayerMask mousePlaneLM;

    private void Awake()
    {
        // Set the instance to this MouseWorld object on initialization
        instance = this;
    }

    // Static method to get the world position of the mouse cursor
    public static Vector3 GetMousePosition()
    {
        // Cast a ray from the main camera through the mouse position on the screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Raycast against the specified layer to find the point on the "mouse plane"
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLM);

        // Return the world position where the ray intersects the mouse plane
        return raycastHit.point;
    }
}