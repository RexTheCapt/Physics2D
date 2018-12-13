#region usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class DangerScript : MonoBehaviour
    {
        [UsedImplicitly]
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}