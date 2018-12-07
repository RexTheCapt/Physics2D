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
        public bool Active = false;

        [UsedImplicitly]
        void Update()
        {
            transform.LookAt(TargetTransform);

            RotatoryGameObject.SetActive(Active);
        }
    }
}