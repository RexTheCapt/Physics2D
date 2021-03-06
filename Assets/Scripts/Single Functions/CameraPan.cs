﻿#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class CameraPan : MonoBehaviour
    {
        private Vector3 _lastPosition;
        public PauseScript PauseScript;

        [UsedImplicitly]
        private void Update()
        {
            if (!PauseScript.GamePaused)
            {
                if (Input.GetButtonDown("Fire2")) _lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Input.GetButton("Fire2"))
                {
                    Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _lastPosition;
                    transform.Translate(0 - delta.x, 0 - delta.y, 0);
                    _lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
    }
}
