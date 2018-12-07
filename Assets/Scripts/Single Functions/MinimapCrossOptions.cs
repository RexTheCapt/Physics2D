#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class MinimapCrossOptions : MonoBehaviour
    {
        [Range(0f, 1f)] public float Alpha = 1f;
        public GameObject[] SquareGameObjects;

        [UsedImplicitly]
        void Update()
        {
            foreach (GameObject squareGameObject in SquareGameObjects)
            {
                Material material = squareGameObject.GetComponent<Renderer>().material;
                Color color = material.color;

                color.a = Alpha;

                material.color = color;
            }
        }
    }
}