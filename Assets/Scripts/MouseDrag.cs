#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class MouseDrag : MonoBehaviour
    {
        public float DropVelocity = 5;
        public bool IsDraggable = false;

        private Vector3 _screenPoint;
        private Vector3 _offset;
        private Vector3[] _positionVector3 = new Vector3[2];
        private bool _disableDrag;

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
        [UsedImplicitly]
        void Update()
        {
            _positionVector3[1] = _positionVector3[0];
            _positionVector3[0] = transform.position;
        }

        /// <summary>
        /// Called when mouse button is clicked on object.
        /// </summary>
        [UsedImplicitly]
        void OnMouseDown()
        {
            if (IsDraggable)
            {
                _screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
                _disableDrag = false;
            }
        }

        /// <summary>
        /// Called every frame if mouse button is not released.
        /// </summary>
        [UsedImplicitly]
        void OnMouseDrag()
        {
            if (!_disableDrag && IsDraggable)
            {
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
                transform.position = curPosition;

                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.velocity = (_positionVector3[0] - _positionVector3[1]) * DropVelocity;
                }
            }
        }

        /// <summary>
        /// Called when object is colliding with an another object.
        /// </summary>
        /// <param name="collision"></param>
        [UsedImplicitly]
        void OnCollisionEnter(Collision collision)
        {
            if (!_disableDrag)
                transform.position = _positionVector3[1];
            _disableDrag = true;
        }
    }
}