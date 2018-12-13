#region usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class EnableCanvas : MonoBehaviour
    {
        public GameObject CanvasGameObject;

        [UsedImplicitly]
        private void Start()
        {
            CanvasGameObject.SetActive(true);
        }
    }
}