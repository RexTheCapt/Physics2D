#region Usings

using JetBrains.Annotations;
using UnityEngine;

#endregion

namespace Assets.Scripts.Single_Functions
{
    public class GoalEffectScript : MonoBehaviour
    {
        [SerializeField]
        private float _deltaTime;

        public GameObject ChildGameObject;
        public float MaxScale = 2f;
        public float MinScale = 1f;
        public float Speed = 1f;
        public int Stage;

        // Update is called once per frame
        [UsedImplicitly]
        private void Update()
        {
            _deltaTime = Time.deltaTime;

            Vector3 scale = gameObject.transform.localScale;

            switch (Stage)
            {
                case 0: // Expand
                    scale += GetAddition();

                    if (scale.y >= MaxScale)
                        Stage++;
                    break;
                case 1: // Implode
                    scale -= GetAddition();

                    if (scale.y <= MinScale)
                        Stage++;
                    break;
                case 2: // Destroy
                    Destroy(gameObject);
                    break;
            }

            transform.localScale = scale;
        }

        private Vector3 GetAddition()
        {
            return new Vector3(Speed * _deltaTime, Speed * _deltaTime, Speed * _deltaTime);
        }
    }
}