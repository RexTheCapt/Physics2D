#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class CursorControl : MonoBehaviour
    {
        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag != "Ball")
                    {
                        Debug.Log(hit.transform.gameObject.name);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}