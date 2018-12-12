#region usings

using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class DangerScript : MonoBehaviour
    {
        void OnTriggerEnter(Collider collision)
        {
            Destroy(collision.gameObject);
        }
    }
}