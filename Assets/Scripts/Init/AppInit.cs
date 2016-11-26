using TimiShared.Debug;
using TimiShared.Init;
using TimiShared.Loading;
using TimiShared.UI;
using UnityEngine;

namespace TimiTracking.Init {
    public class AppInit : MonoBehaviour, IInitializable {

        #region IInitializable
        public void StartInitialize() {
            GameObject mainPanel = null;
            PrefabLoader.Instance.InstantiateAsynchronous("Prefabs/UI/MainPanel", UIRootView.Instance.MainCanvas.transform, (loadedGO) => {
                mainPanel = loadedGO;
                if (mainPanel == null) {
                    TimiDebug.LogErrorColor("null", LogColor.red);
                }
            });
        }

        public bool IsFullyInitialized() {
            return false;
        }
        #endregion
    }
}