using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Base.Game;

public class main : MonoBehaviour
{
    private string TAG = "main";
    private GameManager gameManager_ = new GameManager();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{TAG} Start");
        // 初始化游戏管理器
        gameManager_.Init();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
