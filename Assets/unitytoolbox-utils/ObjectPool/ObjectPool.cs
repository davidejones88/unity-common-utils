namespace UnityToolBox.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ObjectPool : MonoBehaviour
    {
        private readonly Queue<GameObject> inactiveObjects = new Queue<GameObject>();

        [SerializeField] private int initialPoolSize = 0;
        [SerializeField] private bool canExpandList = true;
        [SerializeField] private GameObject poolPrefab = null;

        /// <summary>
        /// Attempts to return a GameObject from the pool.
        /// </summary>
        /// <returns>An instance of the ObjectPool prefab or null if it was not possible to return a GameObject.</returns>
        public GameObject GetObject()
        {
            GameObject gameObject = null;

            if (inactiveObjects.Count > 0)
            {
                gameObject = inactiveObjects.Dequeue();
                PrepareGameObject(ref gameObject);
            }
            else if (canExpandList)
            {
                gameObject = CreateGameObject();
                PrepareGameObject(ref gameObject);
            }

            return gameObject;
        }

        public void ReturnObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.parent = transform;
            inactiveObjects.Enqueue(gameObject);
        }

        private GameObject CreateGameObject()
        {
            GameObject gameObject = Instantiate(poolPrefab);
            gameObject.transform.parent = transform;
            gameObject.SetActive(false);
            PooledObject pooledObject = gameObject.AddComponent<PooledObject>();
            pooledObject.Owner = this;
            return gameObject;
        }

        private GameObject PrepareGameObject(ref GameObject gameObject)
        {
            gameObject.transform.parent = null;
            gameObject.SetActive(true);
            return gameObject;
        }

        private void Awake()
        {
            for (int i = 0; i < initialPoolSize; ++i)
            {
                GameObject gameObject = CreateGameObject();
                inactiveObjects.Enqueue(gameObject);
            }
        }
    }
}
