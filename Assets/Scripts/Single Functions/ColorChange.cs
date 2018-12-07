#region Usings

using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class ColorChange : MonoBehaviour
    {
        private Material _material;
        private Renderer _renderer;
        private Random rdm = new Random();

        [UsedImplicitly]
        void Start()
        {
            _renderer = gameObject.GetComponent<Renderer>();
            _material = new Material(_renderer.material) {color = GetColor()};

            _renderer.material = _material;
        }

        private Color GetColor()
        {
            return new Color((float)rdm.Next(1000) / 1000, (float)rdm.Next(1000) / 1000, (float)rdm.Next(1000) / 1000);
        }
    }
}
