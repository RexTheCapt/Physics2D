#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class GoalScript : MonoBehaviour
    {
        public GameObject GoalEffectGameObject;
        public int CurrentWins;
        public int RequiredWins = 1;
        public bool AddGoal;

        [UsedImplicitly]
        private void Update()
        {
            if (AddGoal)
            {
                AddGoal = false;
                Goal(new GameObject("tmp").AddComponent<BoxCollider>().GetComponent<Collider>());
            }
        }

        [UsedImplicitly]
        private void OnTriggerEnter(Collider collision)
        {
            string colTag = collision.gameObject.tag;

            if (colTag == "Ball")
            {
                AddGoal = false;
                Goal(collision);
            }
        }

        private void Goal(Collider collision)
        {
            CurrentWins++;
            GameObject objectInstantiate = Instantiate(GoalEffectGameObject);
            objectInstantiate.transform.position = gameObject.transform.position;

            objectInstantiate.GetComponent<GoalEffectScript>().ChildGameObject.GetComponent<Renderer>().material =
                collision.gameObject.GetComponent<Renderer>().material;

            Destroy(collision.gameObject);
        }
    }
}
