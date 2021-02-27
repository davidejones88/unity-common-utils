namespace UnityToolBox.Utils
{
    using UnityEngine;

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = LocateOrCreate();
                }

                return instance;
            }
        }

        private static T LocateOrCreate()
        {
            T instance = FindObjectOfType<T>();
            if (instance == null)
            {
                GameObject gameObject = new GameObject();
                instance = gameObject.AddComponent<T>();
                gameObject.name = "Singleton" + typeof(T).Name;
            }

            return instance;
        }
    }
}
