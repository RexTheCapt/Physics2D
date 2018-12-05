#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class MouseDrag : MonoBehaviour
    {
        public float DropVelocity = 5;
        public bool isDraggable = false;

        private Vector3 _screenPoint;
        private Vector3 _offset;
        private Vector3[] positionVector3 = new Vector3[2];
        private bool DisableDrag;

        void Update()
        {
            positionVector3[1] = positionVector3[0];
            positionVector3[0] = transform.position;
        }

        [UsedImplicitly]
        void OnMouseDown()
        {
            if (isDraggable)
            {
                _screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
                DisableDrag = false;
            }
        }

        [UsedImplicitly]
        void OnMouseDrag()
        {
            if (!DisableDrag && isDraggable)
            {
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + _offset;
                transform.position = curPosition;

                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.velocity = (positionVector3[0] - positionVector3[1]) * DropVelocity;
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if(!DisableDrag)
                transform.position = positionVector3[1];
            DisableDrag = true;
        }
    }
}