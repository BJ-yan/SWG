namespace Base.UI
{
    using System;
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class UIManager : MonoBehaviour
    {
        private string TAG = "UIManager";
        private ViewRouter _viewRouter = new ViewRouter();
        
        private Canvas _root;
        public void Init()
        {
            Debug.Log($"{TAG}, UIManager init");
            _root = new GameObject("ROOT").AddComponent<Canvas>();
            _root.GetComponent<RectTransform>().localPosition = new Vector3(0, 20, 0);
        }
        public void AttachView()
        {
            
        }
    }
}
