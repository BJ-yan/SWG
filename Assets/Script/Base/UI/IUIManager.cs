namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IUIManager
    {
        /// <summary>
        /// 栈顶界面发生变化时触发的事件
        /// </summary>
        public Action<IPresenter, IPresenter> ActiveViewChanged { set; get; }

        /// <summary>
        /// 场景中的UI根节点
        /// </summary>
        public Transform UIRoot { get; set; }

        /// <summary>
        /// 当前显示的Presenter对象
        /// </summary>
        public IPresenter CurrentPresenter { get; }

        #region View切换
        /// <summary>
        /// 跳转到View。缓存当前View并跳转到新的View。新View入栈。
        /// </summary>
        /// <param name="vmType">待跳转的ViewModel</param>
        /// <param name="pExtraData">传给下一个Presenter的参数</param>
        /// <param name="vmArgs">ViewModel构造函数参数</param>
        public void NavigateToView(Type vmType, object pExtraData = null, params object[] vmArgs);

        /// <summary>
		/// 返回到上一个View。销毁当前View并返回到上一个缓存的View。当前View出栈。
		/// </summary>
		/// <param name="pExtraData">传给下一个Presenter的参数</param>
        /// /// <param name="parent">传给下一个Presenter的参数</param>
        public void NavigateBackView(Transform parent, object pExtraData = null);

        /// <summary>
        /// 在当前View中创建并显示子View。View不会入栈。
        /// </summary>
        /// <param name="vmType">待跳转的ViewModel</param>
        /// <param name="pExtraData">传给下一个Presenter的参数</param>
        /// <param name="vmArgs">ViewModel构造函数参数</param>
        public void AttachView(Type vmType, object pExtraData = null, params object[] vmArgs);

        /// <summary>
        /// 关闭当前View内部打开的View。
        /// </summary>
        /// <param name="vmType">需要关闭的VM</param>
        /// <param name="refresh">是否需要刷新主View</param>
        public void DetachView(Type vmType, bool refresh = false, bool force = false);

        public enum NavigateType
        { 
            NavigateTo,
            NavigateBack,
            SwitchTo,
        }
        #endregion
    }
}