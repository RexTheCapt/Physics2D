#region usings

using UnityEngine;

#endregion

namespace Assets.Scripts
{
    public class DangerScript : MonoBehaviour
    {
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}