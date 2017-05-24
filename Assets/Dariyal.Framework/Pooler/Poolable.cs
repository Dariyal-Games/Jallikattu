using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dariyal.Framework.Pooler
{
    [Serializable]
    [ExecuteInEditMode]
    public sealed class Poolable : Parkable, IRecyclable
    {
        [SerializeField]
        [HideInInspector]
        ObjectPool pool;

        static bool scriptBuiltInstance;

        private void Awake()
        {
            InstantiationGuard();
            ExecuteEvents.Execute<IPoolableAware>(gameObject, null, (script, ignored) => script.PoolableAwoke(this));
        }

        private void InstantiationGuard()
        {
            if (!scriptBuiltInstance)
            {
                DestroyImmediate(this, true);
                throw new InvalidOperationException("Can only be created with AddPoolableComponent");
            }

            scriptBuiltInstance = false;
        }

        private void OnEnable()
        {
            gameObject.hideFlags = 0;
        }

        private void OnDisable()
        {
            gameObject.hideFlags = HideFlags.HideInHierarchy;
        }

        public void Recycle()
        {
            pool.Recycle(this);
        }

        public static Poolable AddPoolableComponent(GameObject newInstance, ObjectPool pool)
        {
            scriptBuiltInstance = true;
            var instance = newInstance.AddComponent<Poolable>();
            instance.pool = pool;
            return instance;
        }
    }

    public interface IPoolableAware : IEventSystemHandler
    {
        void PoolableAwoke(Poolable p);
    }

    public interface IRecyclable
    {
        void Recycle();
    }

    public abstract class Parkable : MonoBehaviour
    {
        public virtual void Park()
        {
            gameObject.SetActive(false);
        }

        public virtual void Unpark()
        {
            gameObject.SetActive(true);
        }
    }
}
