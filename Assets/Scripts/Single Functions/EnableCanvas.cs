#region usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class EnableCanvas : MonoBehaviour
    {
        public GameObject[] EnableOnStartGameObjects;
        public GameObject[] DisableOnStartGameObjects;

        [UsedImplicitly]
        private void Start()
        {
            foreach (GameObject canvasGameObject in EnableOnStartGameObjects)
            {
                canvasGameObject.SetActive(true);
            }

            foreach (GameObject canvasGameObject in DisableOnStartGameObjects)
            {
                canvasGameObject.SetActive(false);
            }
        }
    }
}