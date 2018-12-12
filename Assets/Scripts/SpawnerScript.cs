#region usings

using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global

#endregion

namespace Assets.Scripts
{
    public class SpawnerScript : MonoBehaviour
    {
        private readonly float MinSpawnTimer = 0.05f;
        private List<Collider> Collisions = new List<Collider>();

        public bool CollisionResetTimer = false;
        public bool IgnoreCollision = false;
        public float SpawnTimer = 5f;
        public float Timer;
        [UsedImplicitly] public GameObject SphereGameObject;

        [UsedImplicitly]
        private void Update()
        {
            Timer += Time.deltaTime;

            if (SpawnTimer < MinSpawnTimer)
                SpawnTimer = MinSpawnTimer;

            if (Timer >= SpawnTimer)
            {
                if (IgnoreCollision)
                    SpawnObject();
                else if (!IgnoreCollision && Collisions.Count == 0) SpawnObject();
            }
        }

        private void SpawnObject()
        {
            var instantiate = Instantiate(SphereGameObject);
            instantiate.transform.position = transform.position;
            Timer = 0;
            Debug.Log("Object spawned");
        }

        [UsedImplicitly]
        private void OnTriggerEnter(Collider collision)
        {
            Collisions.Add(collision);
            Debug.Log("Collision added");
        }

        [UsedImplicitly]
        private void OnTriggerStay(Collider collision)
        {
            if (CollisionResetTimer)
            {
                Timer = 0f;
                Debug.Log("Timer reset");
            }
        }

        [UsedImplicitly]
        private void OnTriggerExit(Collider collision)
        {
            Collisions.Remove(collision);
            Debug.Log("Collision removed");
        }
    }
}