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
        [UsedImplicitly]                                                        // Tell ReSharper this function is in use.
        private void Update()
        {
            CharacterController character = gameObject.GetComponent<CharacterController>();     // get character controller.

            if (!character.isGrounded)                                                          // Check if player is grounded
            {
                _downForce += gravityForce * Time.deltaTime;                                    // Increase the down force.

                if (_downForce > downForceMax)                                                  // If down force is higher than max down force,
                    _downForce = downForceMax;                                                  // Then set down force to max down force.
            }
            else
            {
                _downForce = 0;                                                                 // Set down force to 0.

                if (Input.GetKey(_jumpCode))                                                    // Check if player wants to jump.
                {
                    _downForce = 0 - JumpSpeed;                                                 // Let the player jump.
                }
            }

                                                                                                // Move the player.
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
            if (Input.GetKey(positive)) // Check if forward is pressed.
            {
                return 1f;              // Return positive
            }

            if (Input.GetKey(negative)) // Check if backward is pressed.
            {
                return -1f;             // Return negative.
            }

            return 0;                   // Return zero.
        }
    }
}