// 所谓Navigator
namespace Base.UI
{
    using System;
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class UIManager : IUIManager
    {
        private string TAG = "UIManager";
        public ViewRouter CurViewRouter = new ViewRouter();
        public Action<IPresenter, IPresenter> ActiveViewChanged { get; set; }
        public Transform UIRoot
        {
            get
            {
                return CurViewRouter?.UIRoot;
            }

            set
            {
                CurViewRouter.UIRoot = value;
            }
        }

        public IPresenter CurrentPresenter
        {
            get
            {
                return CurViewRouter?.GetTopPresenter();
            }
        }

        public void NavigateToView(Type vmType, object pExtraData = null, params object[] vmArgs)
        {
            Debug.Log($"{TAG} NavigateToView {vmType}");
            CurViewRouter?.NavigateToView(vmType, null, pExtraData, vmArgs);
        }

        public void NavigateBackView(Transform parent, object pExtraData = null)
        {
            Debug.Log($"{TAG} NavigeteBackView");
            CurViewRouter?.NavigateBackView(pExtraData, parent);
        }

        public void AttachView(Type vmType, object pExtraData = null, params object[] vmArgs)
        {
            Debug.Log($"{TAG} AttachView");
            CurViewRouter?.AttachView(vmType, pExtraData, vmArgs);
        }

        public void DetachView(Type vmType, bool refresh, bool force)
        {
            Debug.Log($"{TAG} DetachView");
            CurViewRouter?.DetachView(vmType, refresh, force);
        }
    }
}
