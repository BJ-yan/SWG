namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IUIManager
    {
        /// <summary>
        /// ջ�����淢���仯ʱ�������¼�
        /// </summary>
        public Action<IPresenter, IPresenter> ActiveViewChanged { set; get; }

        /// <summary>
        /// �����е�UI���ڵ�
        /// </summary>
        public Transform UIRoot { get; set; }

        /// <summary>
        /// ��ǰ��ʾ��Presenter����
        /// </summary>
        public IPresenter CurrentPresenter { get; }

        #region View�л�
        /// <summary>
        /// ��ת��View�����浱ǰView����ת���µ�View����View��ջ��
        /// </summary>
        /// <param name="vmType">����ת��ViewModel</param>
        /// <param name="pExtraData">������һ��Presenter�Ĳ���</param>
        /// <param name="vmArgs">ViewModel���캯������</param>
        public void NavigateToView(Type vmType, object pExtraData = null, params object[] vmArgs);

        /// <summary>
		/// ���ص���һ��View�����ٵ�ǰView�����ص���һ�������View����ǰView��ջ��
		/// </summary>
		/// <param name="pExtraData">������һ��Presenter�Ĳ���</param>
        /// /// <param name="parent">������һ��Presenter�Ĳ���</param>
        public void NavigateBackView(Transform parent, object pExtraData = null);

        /// <summary>
        /// �ڵ�ǰView�д�������ʾ��View��View������ջ��
        /// </summary>
        /// <param name="vmType">����ת��ViewModel</param>
        /// <param name="pExtraData">������һ��Presenter�Ĳ���</param>
        /// <param name="vmArgs">ViewModel���캯������</param>
        public void AttachView(Type vmType, object pExtraData = null, params object[] vmArgs);

        /// <summary>
        /// �رյ�ǰView�ڲ��򿪵�View��
        /// </summary>
        /// <param name="vmType">��Ҫ�رյ�VM</param>
        /// <param name="refresh">�Ƿ���Ҫˢ����View</param>
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