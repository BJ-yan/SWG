namespace Util
{
    using System;
    using UnityEngine;
    using System.Collections.Generic;


    public class AssetLoader : IAssetLoader
    {
       public static T ResourcesLoad<T>(string path) where T : UnityEngine.Object
       {
            return Resources.Load<T>(path);
       }

       public static T[] ResourceLoadAll<T>(string path) where T : UnityEngine.Object
       {
            return Resources.LoadAll<T>(path);
       }

        public static string getPrefabPath(string ViewName)
        {
            return "";
        }
    }
}
