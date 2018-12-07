#region Usings

using System.Linq;
using Assets.Scripts.Single_Functions;
using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class CursorControl : MonoBehaviour
    {
        private class Select
        {
            private GameObject _selectedGameObject;

            private PlatformRotationControl Prc
            {
                get
                {
                    return _selectedGameObject ? _selectedGameObject.gameObject.GetComponent<PlatformRotationControl>() : null;
                }
            }

            public GameObject SelectedGameObject
            {
                [UsedImplicitly]
                get { return _selectedGameObject; }
                set
                {
                    if (Prc != null)
                        Prc.Active = false;

                    _selectedGameObject = value;

                    if (Prc != null)
                        Prc.Active = true;
                }
            }
        }

        private readonly Select _select = new Select();

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [SerializeField] private string[] _blacklistNames = { "DirectionPointer" };

        /// <summary>
        /// Called every frame.
        /// </summary>
        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (!_blacklistNames.Contains(hit.transform.gameObject.name))
                        _select.SelectedGameObject = hit.transform.gameObject;
                }
                else
                {
                    _select.SelectedGameObject = null;
                }
            }
        }
    }
}