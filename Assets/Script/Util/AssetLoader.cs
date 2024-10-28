namespace util
{
    using System;
    using UnityEngine;
    using System.Collections.Generic;


    public class AssetLoader : IAssetLoader
    {
       public T ResourcesLoad<T>(string path) where T : UnityEngine.Object
       {
            return Resources.Load<T>(path);
       }

       public T[] ResourceLoadAll<T>(string path) where T : UnityEngine.Object
       {
            return Resources.LoadAll<T>(path);
       }
    }
}
