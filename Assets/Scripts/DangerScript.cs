#region usings

using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class DangerScript : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);
        }
    }
}