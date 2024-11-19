namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IViewLoader
    {
        /// <summary>
        /// ����View
        /// </summary>
        /// <param name="viewName">View����</param>
        /// <param name="parent">View�ĸ��ڵ�</param>
        /// <returns></returns>
        public void CreateView(string viewName, Transform parent = null) { }

        /// <summary>
        /// ��View�ű���ӵ�����Ľڵ���, �˷����������Prefab
        /// </summary>
        /// <param name="viewName">View����</param>
        /// <param name="parent">View�ĸ��ڵ�</param>
        /// <returns></returns>
        public void AddView(string viewName, Transform parent = null) { }

        /// <summary>
        /// Ԥ����View
        /// </summary>
        /// <param name="viewName">View����</param>
        /// <returns></returns>
        public void PreloadView(string viewName) { }

        /// <summary>
        /// Ԥ����Prefab
        /// </summary>
        /// <param name="prefabName">prefab·��</param>
        /// <param name="resourceModuleIndex">��Դ����</param>
        /// <returns></returns>
        public void PreLoadPrefab(string prefabName, int resourceModuleIndex) { }

        /// <summary>
        /// View��Դ�Ƿ��Ѽ���
        /// </summary>
        /// <param name="viewName">View����</param>
        /// <returns></returns>
        public void IsViewLoaded(string viewName) { }

        /// <summary>
        /// ����View
        /// </summary>
        /// <param name="view">View</param>
        public void CacheView(IView view);

        /// <summary>
        /// ɾ��View
        /// </summary>
        /// <param name="view">View</param>
        /// <param name="keepAssetOnLoadScene">�Ƿ񱣳ֻ����Prefab</param>
        public void DestroyView(IView view, bool keepAssetOnLoadScene = false);

        /// <summary>
        /// ������View����
        /// </summary>
        public void ClearCacheViewPool();

        /// <summary>
        /// �������л���
        /// </summary>
        public void ClearCache();
    }
}
