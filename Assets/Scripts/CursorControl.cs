#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class CursorControl : MonoBehaviour
    {
        /// <summary>
        /// Called every frame.
        /// </summary>
        [UsedImplicitly]                                                        // Tell ReSharper this function is in use.
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))                                   // Check if button is pressed.
            {
                RaycastHit hit;                                                 // Create a new hit.
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // Send out an ray from mouse position.

                if (Physics.Raycast(ray, out hit))                              // Check if the ray hit something.
                {
                    if (hit.transform.gameObject.tag != "Ball")                 // Check game object tag.
                    {
                        Debug.Log(hit.transform.gameObject.name);               // Write a debug message.
                        Destroy(hit.transform.gameObject);                      // Destroy the hit object.
                    }
                }
            }
        }
    }
}