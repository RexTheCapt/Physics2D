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
                if (!_gameControl.EditGame)
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

        private GameControl _gameControl;

        [UsedImplicitly]
        void Start()
        {
            _gameControl = GameObject.Find("Game").GetComponent<GameControl>();
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