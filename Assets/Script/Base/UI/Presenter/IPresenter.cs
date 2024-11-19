namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IPresenter
    {
        /// <summary>
	    /// 该Presenter的唯一id
	    /// </summary>
	    int Id { get; }

        /// <summary>
        /// Presenter标记，当前Presenter的类型全名称，只读属性
        /// 比如 "jj.ChinaChess.Runtime.XXX"
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Presenter管理的所有View，包括主view
        /// </summary>
        List<IView> Views { get; set; }

        /// <summary>
        /// 主View，一般是Views列表中的第一个View
        /// </summary>
        IView MainView { get; }

        /// <summary>
        /// 与View绑定的ViewModel
        /// </summary>
        IViewModel ViewModel { get; set; }

        /// <summary>
        /// 全局View加载器
        /// </summary>
        IViewLoader ViewLoader { get; }

        /// <summary>
        /// Presenter对象是否被释放
        /// </summary>
        bool Disposed { get; }

        /// <summary>
        /// 切换到当前Presenter时由上一个Presenter传入的参数
        /// </summary>
        object ExtraData { get; set; }

        /// <summary>
        /// 如果是Attach的Presenter，则有一个ParentPresenter
        /// </summary>
        IPresenter ParentPresenter { get; set; }

        /// <summary>
        /// Presenter被创建之后调用, 用于数据初始化以及加载View等操作
        /// </summary>                   
        /// <returns></returns>
        public void Prepare();

        /// <summary>
        /// 此方法被调用表示Presenter所持有的View即将恢复
        /// </summary>
        public void OnResume();

        /// <summary>
        /// 此方法被调用表示Presenter所持有的View即将暂停
        /// </summary>
        public void OnPause();

        /// <summary>
        /// 此方法被调用表示Presenter所持有的View以及ViewModel即将被释放
        /// </summary>
        public void Dispose();
    }
}
