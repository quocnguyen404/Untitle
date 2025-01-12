using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Prefabs
    {
        private Dictionary<Prefab, GameObject> prefabs;

        public Prefabs()
        {
            prefabs = new Dictionary<Prefab, GameObject>();
        }

        public T GetPrefab<T>(Prefab type) where T : MonoBehaviour
        {
            if(!prefabs.ContainsKey(type))
            {
                GameObject prefab = Resources.Load<GameObject>(string.Format(GameConstant.PREFAB_PATH, type.ToString()));
                if(prefab == null)
                {
                    Debug.LogError("Try to load " + type.ToString());
                    return null;
                }
                prefabs.Add(type, prefab);
            }
            return prefabs[type].GetComponent<T>();
        }
    }

}
