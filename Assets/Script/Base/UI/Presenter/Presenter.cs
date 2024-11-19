namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Presenter : IPresenter
    {
#region 属性
        public int Id { get; }
        public string Tag
        {
            get { return this.GetType().FullName; }
        }

        public List<IView> Views { get; set; } = new List<IView>();

        public IView MainView
        {
            get
            {
                if (Views.Count > 0)
                {
                    return Views[0];
                }
                return null;
            }
        }

        public IViewModel ViewModel { get; set; }
        public IViewLoader ViewLoader { get; private set; }
        public bool Disposed { get => _disposed; } 

        public object ExtraData { get; set; }

        private bool _disposed;

        public IPresenter ParentPresenter { get; set; }
#endregion

#region 声明周期
        public virtual void Prepare()
        { 
            //TODO ViewLoader赋值
        }

        public virtual void OnResume(){}
        public virtual void OnPause(){}

        public virtual void Dispose()
        {
            _disposed = true;
        }

#endregion
    }
}