namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Util;
    public class ViewLoader : MonoBehaviour, IViewLoader
    {
        class ViewInfo
        {
            public string ViewName;
            public string PrefabPath;
            public GameObject CachePrefab;
        }

        private Dictionary<string, ViewInfo> _cacheViewInfos;

        public void OnStart()
        {
            _cacheViewInfos = new Dictionary<string, ViewInfo>();
        }

        public void CreateView(string viewName, Transform parent)
        {
            var view = Instantiate(viewName, parent);
        }

        private IView Instantiate(string viewName, Transform parent)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                return null;
            }

            // 从缓存中获取，如果缓存没有重新加载prefab
            var viewInfo = GetOrCreateViewInfo(viewName);
            GameObject viewPrefab = GetOrCreatePrefab(viewInfo);


        }

        private ViewInfo GetOrCreateViewInfo(string viewName)
        {
            var viewInfo = _cacheViewInfos.Values.Where(v => v.ViewName == viewName) as ViewInfo;
            if (viewInfo != null)
            {
                return viewInfo;
            }
            else
            {
                var newViewInfo = new ViewInfo()
                {
                    ViewName = viewName,
                    PrefabPath = AssetLoader.getPrefabPath(viewName),
                };
                return newViewInfo;
            }
        }

        private GameObject GetOrCreatePrefab(ViewInfo viewInfo)
        {
            GameObject prefab = viewInfo.CachePrefab;
            if (prefab == null)
            {
                prefab = AssetLoader.ResourcesLoad<GameObject>(viewInfo.PrefabPath);
                viewInfo.CachePrefab = prefab;
            }
            return prefab;
        }

        private GameObject CreateGameObjectFunc(GameObject prefab)
        {
            if (prefab == null)
            {
                return null;
            }

            return UnityEngine.Object.Instantiate(prefab);
        }

        private void initGameObject(GameObject go)
        {
            go.transform.SetParent(null);
            go.SetActive(true);
        }

        private void ReleaseGameObject(GameObject go)
        {
            go.SetActive(false);
        }
        //public void OnDestory()
        //{
        //    ClearCache();
        //}



    }
}
