namespace UnityToolBox.Utils
{
    using UnityEngine;

    public static class PooledGameObjectExtension
    {
        public static void ReturnToPool(this GameObject gameObject)
        {
            PooledObject pooledObject = gameObject.GetComponent<PooledObject>();
            if (pooledObject == null)
            {
                Debug.LogErrorFormat("Cannot return this object to the pool because it was not created using the pool");
            }

            pooledObject.Owner.ReturnObject(gameObject);
        }
    }
}
