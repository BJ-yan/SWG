namespace Util
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    /*
        资源加载的通常有两种方式：
        Resources:
            只需要将需要加载到场景中的资源放置在Asset目录下的Resources文件中
            - FindObjectsOfTypeAll 返回某一种类型的所有资源
            - Laod 通过路径加载资源
            - LoadAll：加载该Resources下的所有资源
            - LoadAsync：异步加载资源，通过协程实现
            - UnloadAsset：卸载加载的资源
            - UnloadUnusedAssets：卸载在内存分钟未使用的资源
    */
    public interface IAssetLoader
    {
        // Load
        public T ResourcesLoad<T>(string path) where T : UnityEngine.Object { return default; }
        // LoadAll
        public T[] ResourcesLoadAll<T>(string path) where T : UnityEngine.Object { return default; }
    }
}