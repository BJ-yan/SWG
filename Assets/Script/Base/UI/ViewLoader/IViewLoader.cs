namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IViewLoader
    {
        /// <summary>
        /// 加载View
        /// </summary>
        /// <param name="viewName">View类名</param>
        /// <param name="parent">View的父节点</param>
        /// <returns></returns>
        public void CreateView(string viewName, Transform parent = null) { }

        /// <summary>
        /// 将View脚本添加到传入的节点上, 此方法不会加载Prefab
        /// </summary>
        /// <param name="viewName">View类名</param>
        /// <param name="parent">View的父节点</param>
        /// <returns></returns>
        public void AddView(string viewName, Transform parent = null) { }

        /// <summary>
        /// 预加载View
        /// </summary>
        /// <param name="viewName">View类名</param>
        /// <returns></returns>
        public void PreloadView(string viewName) { }

        /// <summary>
        /// 预加载Prefab
        /// </summary>
        /// <param name="prefabName">prefab路径</param>
        /// <param name="resourceModuleIndex">资源索引</param>
        /// <returns></returns>
        public void PreLoadPrefab(string prefabName, int resourceModuleIndex) { }

        /// <summary>
        /// View资源是否已加载
        /// </summary>
        /// <param name="viewName">View类名</param>
        /// <returns></returns>
        public void IsViewLoaded(string viewName) { }

        /// <summary>
        /// 缓存View
        /// </summary>
        /// <param name="view">View</param>
        public void CacheView(IView view);

        /// <summary>
        /// 删除View
        /// </summary>
        /// <param name="view">View</param>
        /// <param name="keepAssetOnLoadScene">是否保持缓存的Prefab</param>
        public void DestroyView(IView view, bool keepAssetOnLoadScene = false);

        /// <summary>
        /// 清理缓存View对象
        /// </summary>
        public void ClearCacheViewPool();

        /// <summary>
        /// 清理所有缓存
        /// </summary>
        public void ClearCache();
    }
}
