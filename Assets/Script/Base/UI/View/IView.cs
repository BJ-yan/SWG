namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IView 
    {
        /// <summary>
        /// View的唯一标识
        /// </summary>
        int Id { get; }

        /// <summary>
        /// View名称, 一般是View所在的GameObject名字
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// View标记，当前View的类型全名称，只读属性
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// 跳转到View的自定义参数, 由所在的Presenter传入
        /// </summary>
        object ExtraData { get; set; }

        /// <summary>
        /// View所在GameObject的父节点的Transform
        /// </summary>
        Transform Parent { get; }

        /// <summary>
        /// View关联的Transform组件
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// View所在GameObject
        /// </summary>
        GameObject GameObject { get; }

        /// <summary>
        /// 标识当前View的可见性
        /// 即使View所在GameObject的Active属性为True, 但是透明度或者缩放值为0，也应该标记为不可见
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// 当前View是否加载完成
        /// </summary>
        bool IsPrepared { get; set; }

        /// <summary>
        /// 当前View是否被销毁, GameObject为空时为被销毁状态
        /// </summary>
        bool IsDestroyed { get; }

        /// <summary>
        /// 标识当前View是否可交互
        /// </summary>
        bool Interactable { get; set; }

        /// <summary>
        /// 标识当前View的对象是否缓存
        /// </summary>
        bool IsCache { get; set; }

        /// <summary>
        /// View创建完成并关联ViewModel之后调用，此方法可用于View内部异步处理以及数据绑定
        /// 注意: 注意: 此时的View处于不可见状态, 仅仅用于初始化数据
        /// </summary>
        public void Prepare(){}

        /// <summary>
        /// 进入动画开始, View开始可见
        /// 如果有切换动画: 进入动画开始后被调用
        /// 如果无切换动画: View的Show方法调用后被调用
        /// </summary>
        public void OnAppearing();

        /// <summary>
        /// 进入动画结束, View处于完全可见状态后被调用
        /// </summary>
        public void OnAppeared();

        /// <summary>
        /// View每次恢复时被调用(界面过渡动画完成之后)
        /// </summary>
        public void OnResume();

        /// <summary>
        /// View每次暂停时被调用(入栈新的界面时)
        /// </summary>
        public void OnPause();

        /// <summary>
        /// 退出过渡动画开始, View开始不可见
        /// 如果有切换动画: View的OnPause方法被调用且退出动画开始后被调用
        /// 如果无切换动画: View的OnPause方法被调用被调用
        /// </summary>
        public void OnDisappearing();

        /// <summary>
        /// 退出过渡动画结束, View完全不可见
        /// 如果有切换动画: 退出动画完成后被调用
        /// 如果无切换动画: View的Hide方法调用后被调用
        /// </summary>
        public void OnDisappeared();

        /// <summary>
        /// View被销毁前的清理操作, 仅调用一次
        /// </summary>
        public void Dispose();

        /// <summary>
        /// 显示
        /// </summary>
        public void Show();

        /// <summary>
        /// 隐藏
        /// </summary>
        public void Hide();

        /// <summary>
        /// 刷新View
        /// </summary>
        public void Refresh();

        /// <summary>
        /// 销毁当前View
        /// </summary>
        public void DestorySelf();

        /// <summary>
        /// 查找子节点
        /// </summary>
        public Transform FindTransform(string nodeName);

        /// <summary>
        /// 设置绑定的ViewModel
        /// </summary>
        /// <param name="dataContext"></param>
        public void SetDataContext(object dataContext);
    }
}
