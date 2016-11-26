using TimiShared.Debug;
using TimiShared.Loading;
using TimiShared.UI;
using UnityEngine;

namespace TimiTracking.MainScene {
    public class MainSceneLoader : MonoBehaviour {

        [SerializeField] private string _mainPanelName;

        #region Unity LifeCycle
        private void Start() {
            this.LoadMainPanelAsync(null);
        }
        #endregion

        private void LoadMainPanelAsync(System.Action callback) {
            if (string.IsNullOrEmpty(this._mainPanelName)) {
                TimiDebug.LogErrorColor("Main panel not set", LogColor.red);
            }

            PrefabLoader.Instance.InstantiateAsynchronous(this._mainPanelName, UIRootView.Instance.MainCanvas.transform, (loadedGO) => {
                if (callback != null) {
                    callback.Invoke();
                }
            });
        }

    }
}