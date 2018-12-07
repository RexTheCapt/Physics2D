#region Usings

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace Assets.Scripts
{
    public class GoalScript : MonoBehaviour
    {
        public int requiredWins = 1;
        public int currentWins = 0;

        void OnTriggerEnter(Collider collision)
        {
            string tag = collision.gameObject.tag;

            if (tag == "Ball")
            {
                currentWins++;
                Destroy(collision.gameObject);
            }
        }
    }
}