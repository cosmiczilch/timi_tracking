using TimiShared.Debug;
using TimiShared.Loading;
using TimiShared.UI;
using UnityEngine;

namespace TimiTracking.MainScene {
    public class MainPanel : MonoBehaviour {
        #region Static
        private const string kMainPanelPrefabName = "Prefabs/UI/MainPanel";
        public static void Present() {
            if (MainPanel.Instance != null) {
                TimiDebug.LogWarningColor("Already loaded an instance of MainPanel", LogColor.red);
                return;
            }
            PrefabLoader.Instance.InstantiateAsynchronous(kMainPanelPrefabName, UIRootView.Instance.MainCanvas.transform, (loadedGO) => {
                MainPanel.Instance = loadedGO.GetComponent<MainPanel>();
                if (MainPanel.Instance == null) {
                    TimiDebug.LogWarningColor("Cannot find " + typeof(MainPanel).Name + " on loaded prefab", LogColor.red);
                }
            });
        }

        public static MainPanel Instance {
            get; private set;
        }
        #endregion

        #region Unity LifeCycle
        private void Awake() {
        }

        private void OnDestroy() {
            MainPanel.Instance = null;
        }
        #endregion

        #region Event Handling
        public void OnCheckinButtonClicked() {
        }
        #endregion

    }
}