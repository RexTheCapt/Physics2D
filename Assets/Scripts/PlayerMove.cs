#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class PlayerMove : MonoBehaviour
    {

        #region Movement settings

        [Header("Movement")]
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable 649
        [SerializeField]
        private float MovementSpeed = 2f;
        [SerializeField] private KeyCode _moveRightCode;
        [SerializeField] private KeyCode _moveLeftCode;
        [SerializeField] private float JumpSpeed = 5;
        [SerializeField] private KeyCode _jumpCode;
#pragma warning restore 649
#pragma warning restore IDE0044 // Add readonly modifier

        #endregion

        [Header("Gravity")]
        [SerializeField] private float downForceMax = 10;
        [SerializeField] private float gravityForce = 20;
        private float _downForce;

        [UsedImplicitly]
        private void Update()
        {
            CharacterController character = gameObject.GetComponent<CharacterController>();

            if (!character.isGrounded)
            {
                _downForce += gravityForce * Time.deltaTime;

                if (_downForce > downForceMax)
                    _downForce = downForceMax;
            }
            else
            {
                _downForce = 0;

                if (Input.GetKey(_jumpCode))
                {
                    _downForce = 0 - JumpSpeed;
                }
            }

            character.Move(new Vector3(GetButton(_moveRightCode, _moveLeftCode) * Time.deltaTime * MovementSpeed, 0 - _downForce, 0));
        }

        private float GetButton(KeyCode positive, KeyCode negative)
        {
            if (Input.GetKey(positive))
            {
                return 1f;
            }

            if (Input.GetKey(negative))
            {
                return -1f;
            }

            return 0;
        }
    }
}