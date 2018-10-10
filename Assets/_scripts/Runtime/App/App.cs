using UnityEngine;

namespace Fiftytwo
{
    public class App : MonoBehaviour
    {
        public static App Instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInitializeOnLoad()
        {
            var instance = Instantiate(AppSettings.Instance.AppPrefab);
            instance.name = AppSettings.Instance.AppPrefab.name;
        }

        private void Awake()
        {
            if (Instance != null)
                throw new UnityException(typeof(App) + " is already instantiated");
            DontDestroyOnLoad(this);
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}
