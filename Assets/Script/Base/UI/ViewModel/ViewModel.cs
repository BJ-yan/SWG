namespace Base.UI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewModel : IViewModel
    {
        public bool _isPrepared = false;
        public Action OnPrepared;

        public IUIManager UIManager { get; }

        public IPresenter Presenter { get; set; }

        public virtual void Prepare() { }

        public virtual void ViewPrepared()
        { 
            _isPrepared = true;
            var cb = OnPrepared;
            OnPrepared = null;
            cb?.Invoke();
        }

        public virtual void ViewAppearing() { }

        public virtual void ViewAppeared() { }

        public virtual void ViewResumed() { }

        public virtual void ViewPaused() { }

        public virtual void ViewDisappearing() { }

        public virtual void ViewDisappeared() { }

        public virtual void ViewDisposed() { }
    }
}
