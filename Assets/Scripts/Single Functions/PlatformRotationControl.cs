#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class PlatformRotationControl : MonoBehaviour
    {
        // ReSharper disable once MemberCanBePrivate.Global
        [UsedImplicitly] public Transform TargetTransform;
        [UsedImplicitly] public GameObject RotatoryGameObject;

        public bool Active
        {
            private get { return _active; }
            set {
                if (!gameControl.EditGame)
                {
                    _active = false;
                }
                else
                {
                    _active = value;
                }
            }
        }

        private bool _active;

        private GameControl gameControl;

        void Start()
        {
            gameControl = GameObject.Find("Game").GetComponent<GameControl>();
            Active = Active;
        }

        [UsedImplicitly]
        void Update()
        {
            transform.LookAt(TargetTransform);
            
            RotatoryGameObject.SetActive(_active);
        }
    }
}