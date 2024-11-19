namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IViewModel
    {
        /// <summary>
        /// 全局界面切换类
        /// </summary>
        IUIManager UIManager { get; }

        /// <summary>
        /// 所属Presenter
        /// </summary>
        IPresenter Presenter { get; set; }

        /// <summary>
        /// 构造后仅调用一次
        /// </summary>
        public void Prepare();

        /// <summary>
        /// View.Prepare之后被调用
        /// 注意: 此时的View处于不可见状态, 仅仅用于初始化数据
        /// </summary>
        public void ViewPrepared();

        /// <summary>
        /// View.OnAppearing之后被调用
        /// </summary>
        public void ViewAppearing();

        /// <summary>
        /// View.OnAppeared之后被调用
        /// </summary>
        public void ViewAppeared();

        /// <summary>
        /// View.OnResumed之后被调用
        /// </summary>
        public void ViewResumed();

        /// <summary>
        /// View.OnPaused之后被调用
        /// </summary>
        public void ViewPaused();

        /// <summary>
        /// View.OnDisappearing之后被调用
        /// </summary>
        public void ViewDisappearing();

        /// <summary>
        /// View.OnDisappeared之后被调用
        /// </summary>
        public void ViewDisappeared();

        /// <summary>
        /// View.Dispose之后被调用
        /// </summary>
        public void ViewDisposed();
    }
}
