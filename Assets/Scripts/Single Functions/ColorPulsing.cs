#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class ColorPulsing : MonoBehaviour
    {
        private bool _fadeUp = true;
        public float Timer;
        public float TimerMin = 0f;
        public float TimerMax = 5f;

        [UsedImplicitly]
        void Update()
        {
            Color color = gameObject.GetComponent<Renderer>().material.color;

            if (_fadeUp)
                Timer += Time.deltaTime;
            else
                Timer -= Time.deltaTime;

            if (Timer > TimerMax)
                _fadeUp = false;
            else if (Timer < TimerMin)
                _fadeUp = true;

            color.a = Timer / TimerMax;

            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}