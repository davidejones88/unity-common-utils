namespace UnityToolBox.Utils
{
    using UnityEngine;

    public class PooledObject : MonoBehaviour
    {
        public ObjectPool Owner { get; set; } = null;
    }
}
