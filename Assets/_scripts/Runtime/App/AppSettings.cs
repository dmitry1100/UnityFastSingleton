using UnityEngine;

namespace Fiftytwo
{
    [CreateAssetMenu]
    public class AppSettings : ScriptableObject
    {
        public static AppSettings Instance;

        public App AppPrefab;

        private void OnEnable()
        {
            if (Instance != null)
                throw new UnityException(typeof(AppSettings) + " is already instantiated");
            Instance = this;
        }

        private void OnDisable()
        {
            Instance = null;
        }
    }
}
