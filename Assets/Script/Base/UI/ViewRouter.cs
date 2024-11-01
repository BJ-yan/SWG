namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewRouter : MonoBehaviour
    {
        // ViewMetaData
        class ViewMetaData
        {
            public NavigateType NavigateType;
            public string VMName;
            public object ExtraData;
        }

        // 切换类型
        enum NavigateType
        {
            NavigateTo,
            NavigateBack,
            SwitchTo,
            RedirectTo,
        }
        
        private string TAG = "ViewRouter";
    
        // 生命周期相关
        public bool Prepared = false;
        public bool Resumed = false;
        public bool Appered = false;

        // View队列
        private Queue<ViewMetaData> _waitViews;

        public void Prepare(){}

        public void Resume(){}

        public void ViewAppeared(){}

        public void NavigateToView(string vmName, object extraData)
        {
            CheckEnqueueWaitView(NavigateType.NavigateTo, vmName, extraData);
        }

        // 处理等待队列
        private void CheckEnqueueWaitView(NavigateType navigateType, string vmName, object extraData)
        {
            var viewMetaData = new ViewMetaData()
            {
                NavigateType = navigateType,
                VMName = vmName,
                ExtraData = extraData,
            };
            _waitViews.Enqueue(viewMetaData);
            CheckToNextView();
        }

        private void CheckToNextView()
        {
            if (_waitViews.Count == 0)
            {
                return;
            }
            var viewMetaData = _waitViews.Dequeue();
            switch (viewMetaData.NavigateType)
            {
                case NavigateType.NavigateTo:
                    {
                        Debug.Log($"{TAG}, CheckToNextView NavigaTo");
                        break;
                    }
                default:
                    {
                        Debug.Log($"{TAG}, CheckToNextView Default");
                        break;
                    }
            }
        }


    }
}
