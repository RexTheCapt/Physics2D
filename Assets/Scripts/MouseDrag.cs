#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class MouseDrag : MonoBehaviour
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public float DropVelocity = 5;                                              // When object is no longer being dragged this force is applied.
        // ReSharper disable once MemberCanBePrivate.Global
        public bool IsDraggable = false;                                            // Toggle if object can be dragged or not.

        private Vector3 _screenPoint;                                               // Stores transformed position from world space into screen space.
        private Vector3 _offset;                                                    // Offset for dragging the object.
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Vector3[] _positionVector3 = new Vector3[2];                         // Store current and last position of object.
        private bool _disableDrag;                                                  // A boolean to disable dragging if something happens.

        [UsedImplicitly]
        void Start()
        {
            for (int i = 0; i < _positionVector3.Length; i++)
            {
                _positionVector3[i] = transform.position;
            }
        }

        /// <summary>
        /// Runs every frame.
        /// </summary>
        [UsedImplicitly]                                                            // Tell ReSharper this function is in use.
        void Update()
        {
            _positionVector3[1] = _positionVector3[0];                                // Change current position to last position.
            _positionVector3[0] = transform.position;                                // Store current position.
        }

        /// <summary>
        /// Called when mouse button is clicked on object.
        /// </summary>
        [UsedImplicitly]                                                        // Tell ReSharper this function is in use.
        void OnMouseDown()
        {
            if (IsDraggable)                                                        // If object is draggable then run this block.
            {
                _screenPoint = Camera.main.WorldToScreenPoint(transform.position);  // Store where player clicked on the screen.
                                                                                    // Create an offset relative to the camera and object.
                _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
                _disableDrag = false;                                                // Make sure value is true.
            }
        }

        /// <summary>
        /// Called every frame if mouse button is not released.
        /// </summary>
        [UsedImplicitly]                                                        // Tell ReSharper this function is in use.
        void OnMouseDrag()
        {
            if (!_disableDrag && IsDraggable)                                        // Check if object can be dragged.
            {
                                                                                    // Store current mouse position.
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
                                                                                    // Add offset to current mouse position.
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
                transform.position = curPosition;                                   // Set object position to mouse position.

                Rigidbody rb = gameObject.GetComponent<Rigidbody>();                // Get rigidbody from object.
                if (rb)                                                             // Check if rigidbody exists.
                {
                                                                                    // Set the velocity.
                    rb.velocity = (_positionVector3[0] - _positionVector3[1]) * DropVelocity;
                }
            }
        }

        /// <summary>
        /// Called when object is colliding with an another object.
        /// </summary>
        /// <param name="collision"></param>
        [UsedImplicitly]                                                             // Tell ReSharper this function is in use.
        void OnCollisionEnter(Collision collision)
        {
            if (!_disableDrag)                                                       // Check if value is false.
                transform.position = _positionVector3[1];                             // Transform object to last position.
            _disableDrag = true;                                                     // Disable dragging.
        }
    }
}