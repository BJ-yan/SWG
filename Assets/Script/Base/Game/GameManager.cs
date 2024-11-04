namespace Base.Game
{
    using System.Collections;
    using System.Collections.Generic;
    using Base.UI;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        private string TAG = "GameManager";
        private UIManager uiManager_ = new UIManager();
        public void Init()
        {
            Debug.Log($"{TAG}, GameManager init");
            uiManager_.Init();
        }
    }
}
