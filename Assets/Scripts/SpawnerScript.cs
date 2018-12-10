#region Usings

using System.Collections.Generic;
using UnityEngine;

#endregion

public class SpawnerScript : MonoBehaviour
{
    public GameObject SphereGameObject;
    public bool IgnoreCollision = false;
    public bool CollisionResetTimer = false;
    public float SpawnTimer = 5f;
    private float MinSpawnTimer = 0.05f;

    public float Timer;
    public List<Collider> collisions = new List<Collider>();

    void Update()
    {
        Timer += Time.deltaTime;

        if (SpawnTimer < MinSpawnTimer)
            SpawnTimer = MinSpawnTimer;

        if (Timer >= SpawnTimer)
        {
            if (IgnoreCollision)
            {
                SpawnObject();
            }
            else if (!IgnoreCollision && collisions.Count == 0)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        GameObject instantiate = Instantiate(SphereGameObject);
        instantiate.transform.position = transform.position;
        Timer = 0;
        Debug.Log("Object spawned");
    }

    void OnTriggerEnter(Collider collision)
    {
        collisions.Add(collision);
        Debug.Log("Collision added");
    }

    void OnTriggerStay(Collider collision)
    {
        if (CollisionResetTimer)
        {
            Timer = 0f;
            Debug.Log("Timer reset");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        collisions.Remove(collision);
        Debug.Log("Collision removed");
    }
}