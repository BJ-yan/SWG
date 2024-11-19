namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class ViewPresenter
    {
        /// <summary>
        /// VM对象
        /// </summary>
        public IViewModel ViewModel;

        /// <summary>
        /// Presenter对象
        /// </summary>
        public IPresenter Presenter;

        /// <summary>
        /// Presenter的Transform
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// 额外附带参数
        /// </summary>
        public object ExtraData;

        /// <summary>
        /// 当前界面上attach的界面
        /// </summary>
        public List<ViewPresenter> AttachViews;

        /// <summary>
        /// 是否执行Prepare
        /// </summary>
        public bool IsPrepared = false;

        /// <summary>
        /// 当前界面是否已经恢复到前台
        /// </summary>
        public bool IsResumed = false;

        /// <summary>
        /// 当前界面是否已经在渲染
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

            //Prepare所有View
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

            //Resume所有View
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
