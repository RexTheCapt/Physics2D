#region usings

using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Assets.Scripts
{
    public class GameControl : MonoBehaviour
    {
        public KeyCode ResetKeyCode = KeyCode.R;
        public GameObject ResetTextGameObject;
        public float resetTimeMax = 5f;

        public float resetTime;
        public bool resetInitiated = false;

        #region Private classes

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
            public GameObject[] BallGameObjects;
            public GameObject[] SpawnGameObjects;
            public GameObject[] DangerGameObjects;
        }
        CopyObjects copyObjects = new CopyObjects();

        [UsedImplicitly]
        private void Start()
        {
            copyObjects.BallGameObjects = new GameObject[objects.BallGameObjects.Length];
            copyObjects.SpawnGameObjects = new GameObject[objects.SpawnGameObjects.Length];
            copyObjects.DangerGameObjects = new GameObject[objects.DangerGameObjects.Length];

            // Copy ball objects
            for (int i = 0; i < objects.BallGameObjects.Length; i++)
            {
                copyObjects.BallGameObjects[i] = CreateObject(Instantiate(objects.BallGameObjects[i]), parents.BallParent);
            }

            // Copy spawn objects
            for (int i = 0; i < objects.SpawnGameObjects.Length; i++)
            {
                copyObjects.SpawnGameObjects[i] = CreateObject(Instantiate(objects.SpawnGameObjects[i]), parents.SpawnerParent);
            }

            // Copy danger objects
            for (int i = 0; i < objects.SpawnGameObjects.Length; i++)
            {
                copyObjects.DangerGameObjects[i] = CreateObject(Instantiate(objects.DangerGameObjects[i]), parents.DangerParent);
            }
        }

            #endregion

        // Update is called once per frame
        [UsedImplicitly]
        private void Update()
        {
            if (Input.GetKey(ResetKeyCode))
            {
                resetTime += Time.deltaTime;
            }
            else
            {
                resetTime -= Time.deltaTime;
            }

            if (resetTime < 0)
            {
                resetTime = 0;
                ResetTextGameObject.SetActive(false);
            }

            if (resetTime > resetTimeMax && !resetInitiated)
            {
                resetTime = resetTimeMax + 0.001f;

                resetInitiated = true;

                ResetTextGameObject.GetComponent<Text>().color = new Color(1, 0, 0, 1);

                ResetGameObjects(GameObject.FindGameObjectsWithTag("Ball"), copyObjects.BallGameObjects, parents.BallParent);
                ResetGameObjects(GameObject.FindGameObjectsWithTag("Spawner"), copyObjects.SpawnGameObjects, parents.SpawnerParent);
                ResetGameObjects(GameObject.FindGameObjectsWithTag("Danger"), copyObjects.DangerGameObjects, parents.DangerParent);
            }
            else if (resetTime > 0)
            {
                ResetTextGameObject.SetActive(true);
                ResetTextGameObject.GetComponent<Text>().color = new Color(1, 1, 1, resetTime / resetTimeMax);
            }

            if (resetInitiated)
            {
                resetTime = 0;
                resetInitiated = false;
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
}