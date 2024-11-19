namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class ViewPresenter
    {
        /// <summary>
        /// VM����
        /// </summary>
        public IViewModel ViewModel;

        /// <summary>
        /// Presenter����
        /// </summary>
        public IPresenter Presenter;

        /// <summary>
        /// Presenter��Transform
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// ���⸽������
        /// </summary>
        public object ExtraData;

        /// <summary>
        /// ��ǰ������attach�Ľ���
        /// </summary>
        public List<ViewPresenter> AttachViews;

        /// <summary>
        /// �Ƿ�ִ��Prepare
        /// </summary>
        public bool IsPrepared = false;

        /// <summary>
        /// ��ǰ�����Ƿ��Ѿ��ָ���ǰ̨
        /// </summary>
        public bool IsResumed = false;

        /// <summary>
        /// ��ǰ�����Ƿ��Ѿ�����Ⱦ
        /// </summary>
        public bool IsAppeared = false;

        private bool IsDoViewResumed = false;
        private IUIManager _uiManager;
        private IViewLoader _viewLoader;

        public ViewPresenter(IUIManager uiManager, IViewLoader viewLoader)
        {
            _uiManager = uiManager;
            _viewLoader = viewLoader;
            AttachViews = new List<ViewPresenter>();
        }

        public void PrePared(bool prepareVM)
        {
            if (IsPrepared)
            {
                return;
            }

            if (Presenter == null)
            {
                return;
            }

            if (prepareVM)
            {
                ViewModel?.Prepare();
            }

            Presenter.PrePare();

            //Prepare����View
            foreach (var view in Presenter.Views)
            {
                if (view != null && !view.IsDestoryed)
                {
                    view.Visibility = false;
                    view.ExtraData = ExtraData;
                    view.SetDataContext(ViewModel);

                    view.Prepare();
                    view.IsPrepared = true;
                }
            }

            //ViewModel Prepare
            ViewModel.Prepare();

            //AttatchView Prepare
        }

        public void Resume()
        {
            if (Presenter == null)
            {
                return;
            }
            if (!IsPrepared || IsResumed)
            {
                return;
            }

            Presenter.OnResume();

            //Resume����View
            foreach (var view in Presenter.Views)
            {
                if (view != null && !view.IsDestoryed)
                {
                    view.Show();
                    view.OnAppearing();
                }
            }
        }

        public void ViewAppeared()
        {
            if (Presenter == null)
            {
                return;
            }
            if (!IsPrepared || IsAppeared)
            {
                return;
            }

            foreach (var view in Presenter.Views)
            {
                if (view != null && !view.IsDestroyed)
                {
                    view.OnAppeared();
                }
            }
            Presenter.ViewModel.ViewAppeared();

            IsAppeared = true;
        }

        public void DoViewResume()
        {
            if (Presenter == null)
            {
                return;
            }
            if (!IsPrepared)
            {
                return;
            }

        }

        public void Pause()
        {
            if (Presenter == null)
            {
                return;
            }
            if (!IsPrepared || !IsResumed)
            {
                return;
            }

            foreach (var view in Presenter.Views)
            {
                if (view != null && !view.IsDestroyed)
                {
                    view.OnPause();
                }
            }
            ViewModel.ViewPaused();

            foreach (var view in Presenter.Views)
            {
                if (view != null && !view.IsDestroyed)
                {
                    view.OnDisappearing();
                }
            }
            ViewModel.ViewDisappearing();
        }
    }
}
