#region Usings

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class ColorPulsing : MonoBehaviour
    {
        private bool _fadeUp = true;
        public bool RunWhilePaused = false;
        public float Timer;
        public float TimerMin = 0f;
        public float TimerMid = -1f;
        public float TimerMax = 5f;

        [UsedImplicitly]
        void Update()
        {
            if (RunWhilePaused || Time.timeScale > 0)
            {
                Color color = new Color();

                Renderer renderer = gameObject.GetComponent<Renderer>();
                Image image = gameObject.GetComponent<Image>();

                if (renderer)
                    color = renderer.material.color;
                else if (image)
                    color = image.color;

                if (_fadeUp)
                    Timer += Time.fixedDeltaTime;
                else
                    Timer -= Time.fixedDeltaTime;

                if (TimerMid > TimerMin && Timer > TimerMin)
                {
                    if (Timer > TimerMid)
                        _fadeUp = false;
                }
                else if (Timer > TimerMax)
                    _fadeUp = false;
                else if (Timer < TimerMin)
                    _fadeUp = true;

                color.a = Timer / TimerMax;

                if (renderer)
                    renderer.material.color = color;
                else if (image)
                    image.color = color;
            }
        }
    }
}