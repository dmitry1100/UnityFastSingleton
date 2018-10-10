using System.Reflection;
using UnityEditor;

namespace Fiftytwo
{
    [InitializeOnLoad]
    public class TouchPreloadedAssets
    {
        static TouchPreloadedAssets()
        {
            GetPreloadedAssets();
        }

        private static UnityEngine.Object[] GetPreloadedAssets()
        {
#if UNITY_2018_2_OR_NEWER
            return PlayerSettings.GetPreloadedAssets();
#else
            var findProperty = typeof(PlayerSettings).GetMethod("FindProperty",
                BindingFlags.NonPublic | BindingFlags.Static);
            var preloadedAssetsProp = findProperty.Invoke(null,
                new object[] { "preloadedAssets" }) as SerializedProperty;
            var assets = new UnityEngine.Object[preloadedAssetsProp.arraySize];
            for (int i = assets.Length; --i >= 0;)
            {
                var assetProp = preloadedAssetsProp.GetArrayElementAtIndex(i);
                // Property access forces Unity Editor to load asset
                assets[i] = assetProp.objectReferenceValue;
            }
            return assets;
#endif
        }
    }
}
