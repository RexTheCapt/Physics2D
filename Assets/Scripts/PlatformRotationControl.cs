#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class PlatformRotationControl : MonoBehaviour
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public Transform TargetTransform;

        [UsedImplicitly]
        void Update()
        {
            transform.LookAt(TargetTransform);
        }
    }
}