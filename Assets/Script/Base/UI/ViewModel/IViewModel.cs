namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IViewModel
    {
        /// <summary>
        /// ȫ�ֽ����л���
        /// </summary>
        IUIManager UIManager { get; }

        /// <summary>
        /// ����Presenter
        /// </summary>
        IPresenter Presenter { get; set; }

        /// <summary>
        /// ����������һ��
        /// </summary>
        public void Prepare();

        /// <summary>
        /// View.Prepare֮�󱻵���
        /// ע��: ��ʱ��View���ڲ��ɼ�״̬, �������ڳ�ʼ������
        /// </summary>
        public void ViewPrepared();

        /// <summary>
        /// View.OnAppearing֮�󱻵���
        /// </summary>
        public void ViewAppearing();

        /// <summary>
        /// View.OnAppeared֮�󱻵���
        /// </summary>
        public void ViewAppeared();

        /// <summary>
        /// View.OnResumed֮�󱻵���
        /// </summary>
        public void ViewResumed();

        /// <summary>
        /// View.OnPaused֮�󱻵���
        /// </summary>
        public void ViewPaused();

        /// <summary>
        /// View.OnDisappearing֮�󱻵���
        /// </summary>
        public void ViewDisappearing();

        /// <summary>
        /// View.OnDisappeared֮�󱻵���
        /// </summary>
        public void ViewDisappeared();

        /// <summary>
        /// View.Dispose֮�󱻵���
        /// </summary>
        public void ViewDisposed();
    }
}
