using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class main : MonoBehaviour
{
    private string TAG = "main";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{TAG} Start");
        InitInterfaceManager();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InitInterfaceManager()
    {
        Debug.Log($"{TAG}, InitInterFaceManager");
    }
}