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
        [SerializeField] private KeyCode _moveRightCode;                                // Key to move right.
        [SerializeField] private KeyCode _moveLeftCode;                                 // Key to move left.
        [SerializeField] private float JumpSpeed = 5;                                   // How fast player can jump.
        [SerializeField] private KeyCode _jumpCode;                                     // Key to jump.
#pragma warning restore 649
#pragma warning restore IDE0044 // Add readonly modifier

        #endregion

        [Header("Gravity")]
        [SerializeField] private float downForceMax = 10;                               // Maximum fall force.
        [SerializeField] private float gravityForce = 20;                               // Gravity force.
        private float _downForce;                                                       // fall force.

        /// <summary>
        /// Called every frame.
        /// </summary>
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

        /// <summary>
        /// Get a number depending on two buttons.
        /// </summary>
        /// <param name="positive">Basically forward</param>
        /// <param name="negative">Basically backward</param>
        /// <returns>Pos : 1f, Def : 0f, Neg : -1f</returns>
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