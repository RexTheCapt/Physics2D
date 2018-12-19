#region usings

using System;
using Assets.Scripts.Single_Functions;
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
        public float ResetTimeMax = 5f;
        public bool ResetButtonPressed;

        public bool EditGame
        {
            set
            {
                _editGame = value;
                ResetGame();
            }
            get { return _editGame; }
        }

        private float _resetTime;
        private bool _resetInitiated;
        private bool _editGame;

        #region Private classes

        // Parents
        [Serializable]
        private class Parents
        {
            [UsedImplicitly] public Transform BallParent;
            [UsedImplicitly] public Transform SpawnerParent;
            [UsedImplicitly] public Transform DangerParent;
            [UsedImplicitly] public Transform GoalParent;
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
            [UsedImplicitly] public GameObject[] GoalGameObjects;
        }
        [SerializeField]
        Objects objects = new Objects();

        // Duplicate objects
        private class CopyObjects
        {
            public GameObject[] BallGameObjects;
            public GameObject[] SpawnGameObjects;
            public GameObject[] DangerGameObjects;
            public GameObject[] GoalGameObjects;
        }
        CopyObjects copyObjects = new CopyObjects();

        #endregion

        [UsedImplicitly]
        private void Start()
        {
            copyObjects.BallGameObjects = new GameObject[objects.BallGameObjects.Length];
            copyObjects.SpawnGameObjects = new GameObject[objects.SpawnGameObjects.Length];
            copyObjects.DangerGameObjects = new GameObject[objects.DangerGameObjects.Length];
            copyObjects.GoalGameObjects = new GameObject[objects.GoalGameObjects.Length];

            CreateCopyList(objects.BallGameObjects, copyObjects.BallGameObjects, parents.BallParent);
            CreateCopyList(objects.SpawnGameObjects, copyObjects.SpawnGameObjects, parents.SpawnerParent);
            CreateCopyList(objects.DangerGameObjects, copyObjects.DangerGameObjects, parents.DangerParent);
            CreateCopyList(objects.GoalGameObjects, copyObjects.GoalGameObjects, parents.GoalParent);
        }

        private void CreateCopyList(GameObject[] originalGameObjects, GameObject[] copyGameObjects, Transform parent)
        {
            for (int i = 0; i < originalGameObjects.Length; i++)
            {
                copyGameObjects[i] = CreateObject(Instantiate(originalGameObjects[i]), parent);
            }
        }

        // Update is called once per frame
        [UsedImplicitly]
        protected virtual void Update()
        {
            if (Input.GetKey(ResetKeyCode) || ResetButtonPressed)
            {
                _resetTime += Time.fixedDeltaTime;
            }
            else
            {
                _resetTime -= Time.fixedDeltaTime;
            }

            if (_resetTime < 0)
            {
                _resetTime = 0;
                ResetTextGameObject.SetActive(false);
            }

            if (_resetTime > ResetTimeMax && !_resetInitiated)
            {
                ResetGame();
            }
            else if (_resetTime > 0)
            {
                ResetTextGameObject.SetActive(true);
                ResetTextGameObject.GetComponent<Text>().color = new Color(1, 1, 1, _resetTime / ResetTimeMax);
            }

            if (_resetInitiated)
            {
                _resetTime = 0;
                _resetInitiated = false;
            }
        }

        private void ResetGame()
        {
            _resetTime = ResetTimeMax + 0.001f;

            _resetInitiated = true;

            ResetTextGameObject.GetComponent<Text>().color = new Color(1, 0, 0, 1);

            ResetGameObjects(GameObject.FindGameObjectsWithTag("Ball"), copyObjects.BallGameObjects, parents.BallParent);
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Spawner"), copyObjects.SpawnGameObjects, parents.SpawnerParent);
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Danger"), copyObjects.DangerGameObjects, parents.DangerParent);
            ResetGameObjects(GameObject.FindGameObjectsWithTag("Finish"), copyObjects.GoalGameObjects, parents.GoalParent);
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

                if (_editGame && o.activeInHierarchy)
                {
                    if (o.GetComponent<SpawnerScript>())
                        o.GetComponent<SpawnerScript>().enabled = false;
                    if (o.GetComponent<DangerScript>())
                        o.GetComponent<DangerScript>().enabled = false;
                    if (o.GetComponent<Rigidbody>())
                        o.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    if (o.GetComponent<MouseDrag>())
                        o.GetComponent<MouseDrag>().enabled = false;
                    if (o.GetComponent<GoalScript>())
                        o.GetComponent<GoalScript>().enabled = false;
                }
            }
        }

        public void PressResetButton()
        {
            ResetButtonPressed = true;
        }

        public void ReleaseResetButton()
        {
            ResetButtonPressed = false;
        }
    }
}