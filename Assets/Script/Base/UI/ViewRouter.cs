namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using static Base.UI.IUIManager;

    public class ViewRouter
    {
        class WaitParam
        {
            public Type VMType;
            public object ExtraData;
            public object[] VMArgs;
            public NavigateType NavigateType;
            public Transform Parent;
            public int StackIndex;
        }

        private IUIManager _uiManager;
        private IViewLoader _viewLoader;
        private Transform _uiRoot;
        private Transform _presenterRoot;
        private LinkedList<ViewPresenter> _cacheViews;
        private Queue<WaitParam> _waitViews;
        private bool _readyToNext = true;
        public ViewRouter(IUIManager uiManager, IViewLoader viewLoader)
        {
            _uiManager = uiManager;
            _viewLoader = viewLoader;
            _waitViews = new Queue<WaitParam>(8);
        }
        public Transform UIRoot
        { 
            get => _uiRoot;
            set => _uiRoot = value;
        }

        public void NavigateToView(Type vmType, Transform parent, object pExtraData, params object[] vmArgs)
        {
            OnCheckEnqueueWaitView(NavigateType.NavigateTo, vmType, parent, pExtraData, vmArgs);
        }

        public void NavigateBackView(object pExtraData, Transform parent)
        {
            var top = GetTopPresenter();
            if (top != null)
            {
                return;
            }
            OnCheckEnqueueWaitView(NavigateType.NavigateBack, null, parent, pExtraData);
        }

        public void AttachView(Type vmType, object pExtraData, params object[] vmArgs)
        {
        }

        public void DetachView(Type vmType, bool refresh, bool force)
        { 
        }

        public IPresenter GetTopPresenter()
        {
            //return _ppp;
        }

        private void OnCheckEnqueueWaitView(NavigateType nType, Type vmType, Transform parent, object pExtraData, params object[] vmArgs)
        {
            var param = OnCreateWaitParamObject(nType, vmType, -1, parent, pExtraData, vmArgs);
            _waitViews.Enqueue(param);

            CheckToNextView();
        }

        private void CheckToNextView()
        {
            if (_waitViews.Count == 0)
            {
                return;
            }
            if (!_readyToNext)
            {
                return;
            }
            _readyToNext = false;
            var wait = _waitViews.Dequeue();

            try
            {
                switch (wait.NavigateType)
                {
                    case NavigateType.NavigateTo:
                    {
                        Push(wait);
                        break;
                    }
                    case NavigateType.NavigateBack:
                    {
                        Pop(wait);
                        break;
                    }
                    case NavigateType.SwitchTo:
                    {
                        //if (ContainsViewModel(wait.VMType))
                        //{
                        //    await MoveToTopAsync(wait);
                        //}
                        //else
                        //{
                        //    await PushAsync(wait);
                        //}
                        break;
                        }
                }
            }
            finally 
            { 
            
            }
        }

        private WaitParam OnCreateWaitParamObject(NavigateType nType, Type vmType, int stackIndex, Transform parent, object pExtraData, params object[] vmArgd)
        {
            return new WaitParam()
            {
                VMType = vmType,
                ExtraData = pExtraData,
                StackIndex = stackIndex,
                NavigateType = nType,
                Parent = parent,
            };
        }

        private void Push(WaitParam wait)
        {
            var top = GetTopViewPresenter();
            var cur = CreateVP(wait.VMType, wait.ExtraData, wait.VMArgs);
            _cacheViews.AddFirst(cur);

            cur.PrePared(true);
        }

        private void Pop(WaitParam wait)
        { 
        }

        private ViewPresenter GetTopViewPresenter()
        {
            if (_cacheViews.Count == 0)
            {
                return null;
            }

            return _cacheViews.First.Value;
        }

        private ViewPresenter CreateVP(Type vmType, object pExtraData, params object[] vmArgs)
        {
            if (_presenterRoot == null)
            {
                var presenterGo = GameObject.Find("PresenterRoot") ?? new GameObject("PresenterRoot");
                presenterGo.transform.SetAsFirstSibling();
                _presenterRoot = presenterGo.transform;
            }

            //Create ViewModel
            ViewModel viewModel = new ViewModel();

            //Create Presenter
            Presenter presenter = new Presenter();
            GameObject go = new GameObject(presenter.name);
            go.transform.SetParent(_presenterRoot);
            presenter.ViewModel = viewModel;

            //Create ViewPrsenter
            var viewPresenter = new ViewPresenter(_uiManager, _viewLoader)
            {
                ViewModel = viewModel,
                Presenter = presenter,
                Transform = go.transform,
                ExtraData = pExtraData
            };

            return viewPresenter;
        }

        private void DoViewAppeareChange(ViewPresenter inVP, ViewPresenter outVP, Transform parent)
        {
            inVP?.Resume();
            outVP?.Pause();

            inVP?.ViewAppeared();
            outVP?.DoViewResume();

            outVP?.ViewDisAppeared();
        }
    }
}
