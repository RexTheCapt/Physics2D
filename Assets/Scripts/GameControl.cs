#region usings

using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class GameControl : MonoBehaviour
{
    public KeyCode ResetKeyCode = KeyCode.R;

    // Parents
    [Serializable]
    private class Parents
    {
        [UsedImplicitly] public Transform BallParent;
        [UsedImplicitly] public Transform SpawnerParent;
        [UsedImplicitly] public Transform DangerParent;
    }
    [SerializeField]
    Parents parents = new Parents();

    // Object lists
    [Serializable]
    private class Objects
    {
        [UsedImplicitly] public GameObject[] BallGameObjects;
        [UsedImplicitly] public GameObject[] SpawnGameObjects;
        [UsedImplicitly] public GameObject[] DangerGameObjects;
    }
    [SerializeField]
    Objects objects = new Objects();

    // Duplicate objects
    private class CopyObjects
    {
        public GameObject[] _ballGameObjects;
        public GameObject[] _spawnGameObjects;
        public GameObject[] _dangerGameObjects;
    }
    CopyObjects copyObjects = new CopyObjects();

    private void Start()
    {
        copyObjects._ballGameObjects = new GameObject[objects.BallGameObjects.Length];
        copyObjects._spawnGameObjects = new GameObject[objects.SpawnGameObjects.Length];
        copyObjects._dangerGameObjects = new GameObject[objects.DangerGameObjects.Length];

        // Copy ball objects
        for (int i = 0; i < objects.BallGameObjects.Length; i++)
        {
            copyObjects._ballGameObjects[i] = CreateObject(Instantiate(objects.BallGameObjects[i]), parents.BallParent);
        }

        // Copy spawn objects
        for (int i = 0; i < objects.SpawnGameObjects.Length; i++)
        {
            copyObjects._spawnGameObjects[i] = CreateObject(Instantiate(objects.SpawnGameObjects[i]), parents.SpawnerParent);
        }

        // Copy danger objects
        for (int i = 0; i < objects.SpawnGameObjects.Length; i++)
        {
            copyObjects._dangerGameObjects[i] = CreateObject(Instantiate(objects.DangerGameObjects[i]), parents.DangerParent);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(ResetKeyCode))
        {
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Ball"), copyObjects._ballGameObjects, parents.BallParent);
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Spawner"), copyObjects._spawnGameObjects, parents.SpawnerParent);
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Danger"), copyObjects._dangerGameObjects, parents.DangerParent);
        }
    }

    private GameObject CreateObject(GameObject o, Transform parent)
    {
        o.SetActive(false);
        o.transform.parent = parent;
        return o;
    }

    private void ResetGameObjects(GameObject[] findGameObjectsWithTag, GameObject[] waitingObjects, Transform parent)
    {
        foreach (GameObject o in findGameObjectsWithTag)
        {
            Destroy(o);
        }

        foreach (GameObject waitingObject in waitingObjects)
        {
            GameObject o = Instantiate(waitingObject);

            o.SetActive(true);
            o.transform.parent = parent;
        }
    }
}