using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace HuynnLib
{
    public class LazyPooling : MonoBehaviour
    {
        private static LazyPooling _instant;
        public static LazyPooling Instant => _instant;
        public Transform holder;
        public Transform VFX_Holder;

        private void Awake()
        {
            if (_instant == null)
                _instant = this;
            if (_instant.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
        Dictionary<GameObject, List<GameObject>> _poolObjects2 = new Dictionary<GameObject, List<GameObject>>();

        public GameObject GetGameObj(GameObject objKey, Vector3 position, Quaternion quaternion, Vector3 localScale = default(Vector3), bool isKeepParent = false)
        {
            if (localScale == default(Vector3))
            {
                localScale = Vector3.one;
            }
            
            if (!_poolObjects2.ContainsKey(objKey))
            {
                _poolObjects2.Add(objKey, new List<GameObject>());
            }

            foreach (var g in _poolObjects2[objKey])
            {
                if (g.gameObject.activeSelf)
                    continue;
                
                g.transform.position = position;
                g.transform.rotation = quaternion;
                g.transform.localScale = localScale;
                return g;
            }

            GameObject g2 = Instantiate(objKey, position, quaternion, VFX_Holder);
            g2.gameObject.SetActive(true);
            g2.transform.localScale = localScale;
            _poolObjects2[objKey].Add(g2);

            // if (isKeepParent)
            //     g2.transform.SetParent(objKey.transform.parent);
            return g2;
        }

        Dictionary<Component, List<Component>> _poolObjt = new Dictionary<Component, List<Component>>();
   
        public T getObj<T>(T objKey, Vector3 position, Quaternion quaternion) where T : Component 
        {
            if (!_poolObjt.ContainsKey(objKey))
            {
                _poolObjt.Add(objKey, new List<Component>());
            }

            foreach (T g in _poolObjt[objKey])
            {
                if (g.gameObject.activeSelf)
                    continue;
                g.transform.position = position;
                g.transform.rotation = quaternion;
                return g;
            }

            T g2 = Instantiate(objKey , position, quaternion, holder);
            _poolObjt[objKey].Add(g2);
            g2.gameObject.SetActive(true);

            // if (isKeepParent)
            //     g2.transform.SetParent(objKey.transform.parent);
            return g2;
        }

        public T getObj<T>(T objKey) where T : Component 
        {
            if (!_poolObjt.ContainsKey(objKey))
            {
                _poolObjt.Add(objKey, new List<Component>());
            }

            foreach (T g in _poolObjt[objKey])
            {
                if (g.gameObject.activeSelf)
                    continue;
                return g;
            }

            T g2 = Instantiate(objKey);
            _poolObjt[objKey].Add(g2);
            g2.gameObject.SetActive(true);

            // if (isKeepParent)
            //     g2.transform.SetParent(objKey.transform.parent);
            return g2;
        }

        public T getObj<T>(T objKey, Vector3 position, Quaternion quaternion, Transform parent) where T : Component 
        {
            if (!_poolObjt.ContainsKey(objKey))
            {
                _poolObjt.Add(objKey, new List<Component>());
            }

            foreach (T g in _poolObjt[objKey])
            {
                if (g.gameObject.activeSelf)
                    continue;
                g.transform.position = position;
                g.transform.rotation = quaternion;
                return g;
            }

            T g2 = Instantiate(objKey , position, quaternion, parent);
            _poolObjt[objKey].Add(g2);

            // if (isKeepParent)
            //     g2.transform.SetParent(objKey.transform.parent);
            return g2;
        }

        public void resetObj<T>( T objKey) where T:Component
        {
            if (!_poolObjt.ContainsKey(objKey))
            {
                return;
            }

            foreach (T g in _poolObjt[objKey])
            { 
                g.gameObject.SetActive(false);
            }
        }

        public void OnDespawnAll()
        {
            foreach (var keyValue in _poolObjt)
            {
                foreach (Component obj in keyValue.Value)
                {
                    obj.gameObject.SetActive(false);
                }
            }
        }





        // public void CreatePool<T>(T keyObj, int size) where T : Component
        // {
        //     if (!_poolObjt.ContainsKey(keyObj))
        //     {
        //         _poolObjt.Add(keyObj, new List<Component>());
        //     }
        //     for (int i = 0; i < size; i++)
        //     {
        //         this.getObj<T>(keyObj,true).gameObject.SetActive(false);
        //     }
        // }
    }
}