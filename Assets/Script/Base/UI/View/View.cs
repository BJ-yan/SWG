namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class View : MonoBehaviour, IView
    {
        #region property
        public virtual int Id { get; }

        public string Name
        {
            get { return gameObject.name; }
            set
            {
                gameObject.name = value;
            }
        }

        public string Tag
        {
            get { return this.GetType().FullName; }
        }


        public object ExtraData { get; set; }


        public Transform Parent
        {
            get { return transform.parent; }
        }

        public Transform Transform
        {
            get { return transform; }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public bool IsVisible
        {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        public bool IsPrepared { get; set; }

        public bool IsDestroyed { get; set; }

        public bool Interactable { get; set; }

        public bool IsCache { get; set; }
#endregion

#region 生命周期
        public virtual void Prepare(){}

        public virtual void OnAppearing()
        {
            Interactable = false;
        }

        public virtual void OnAppeared()
        {
            Interactable = true;
        }

        public virtual void OnResume(){}

        public virtual void OnPause(){}

        public virtual void OnDisappearing()
        {
            Interactable = false;
        }

        public virtual void OnDisappeared(){}

        public virtual void Dispose()
        {
            //this.BindingContext().Clear();
            //TODO
        }

        public virtual void Show()
        {
            IsVisible = true;
        }

        public virtual void Hide()
        { 
            IsVisible = false;
        }

        public virtual void Refresh(){}

        public virtual void DestorySelf()
        {
            if (IsDestroyed) return;
            Destroy(this.gameObject);
            IsDestroyed = true;
        }

        public Transform FindTransform(string nodeName)
        {
            if (IsDestroyed) return null;
            return transform.Find(nodeName);
        }

        public void SetDataContext(object dataContext)
        {
            //this.BindingContext().DataContext = dataContext;
        }
#endregion
    }
}