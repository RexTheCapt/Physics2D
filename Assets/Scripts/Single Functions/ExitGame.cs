#region Usings

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class ExitGame : MonoBehaviour
    {
        public float ExitTime = 5f;
        public Text QuitText;
        private float _timer;

        [UsedImplicitly]
        private void Start()
        {
            QuitText.color = new Color(255, 255, 255, _timer / ExitTime);
        }

        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                _timer += Time.deltaTime;
            else
                _timer -= Time.deltaTime;

            if (_timer < 0.1f && Input.GetKeyUp(KeyCode.Escape))
            {
                _timer = 0;
                PauseScript ps = gameObject.GetComponent<PauseScript>();

                ps.Toggle();
            }

            if (_timer > ExitTime)
            {
                _timer = ExitTime;
                QuitText.color = Color.red;
                Application.Quit();
            }
            else if (_timer > 0)
            {
                QuitText.enabled = true;
                QuitText.color = new Color(255, 255, 255, _timer / ExitTime);
            }
            else if (_timer < 0)
            {
                QuitText.enabled = false;
                _timer = 0;
            }
        }
    }
}