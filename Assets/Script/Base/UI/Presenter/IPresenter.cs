namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IPresenter
    {
        /// <summary>
	    /// ��Presenter��Ψһid
	    /// </summary>
	    int Id { get; }

        /// <summary>
        /// Presenter��ǣ���ǰPresenter������ȫ���ƣ�ֻ������
        /// ���� "jj.ChinaChess.Runtime.XXX"
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Presenter���������View��������view
        /// </summary>
        List<IView> Views { get; set; }

        /// <summary>
        /// ��View��һ����Views�б��еĵ�һ��View
        /// </summary>
        IView MainView { get; }

        /// <summary>
        /// ��View�󶨵�ViewModel
        /// </summary>
        IViewModel ViewModel { get; set; }

        /// <summary>
        /// ȫ��View������
        /// </summary>
        IViewLoader ViewLoader { get; }

        /// <summary>
        /// Presenter�����Ƿ��ͷ�
        /// </summary>
        bool Disposed { get; }

        /// <summary>
        /// �л�����ǰPresenterʱ����һ��Presenter����Ĳ���
        /// </summary>
        object ExtraData { get; set; }

        /// <summary>
        /// �����Attach��Presenter������һ��ParentPresenter
        /// </summary>
        IPresenter ParentPresenter { get; set; }

        /// <summary>
        /// Presenter������֮�����, �������ݳ�ʼ���Լ�����View�Ȳ���
        /// </summary>                   
        /// <returns></returns>
        public void Prepare();

        /// <summary>
        /// �˷��������ñ�ʾPresenter�����е�View�����ָ�
        /// </summary>
        public void OnResume();

        /// <summary>
        /// �˷��������ñ�ʾPresenter�����е�View������ͣ
        /// </summary>
        public void OnPause();

        /// <summary>
        /// �˷��������ñ�ʾPresenter�����е�View�Լ�ViewModel�������ͷ�
        /// </summary>
        public void Dispose();
    }
}
