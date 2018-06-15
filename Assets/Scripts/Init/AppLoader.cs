using System.Collections;
using TimiShared.Debug;
using TimiShared.Init;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TimiTracking.Init {
    public class AppLoader : MonoBehaviour, IInitializable {

        [SerializeField] private string _mainSceneName;

        #region IInitializable
        public void StartInitialize() {
            this.StartCoroutine(this.LoadMainSceneAsync((bool sceneLoadSuccess) => {
                if (sceneLoadSuccess) {
                    this.IsFullyInitialized = true;
                }
            }));
        }

        public bool IsFullyInitialized {
            get; private set;
        }

        public string GetName {
            get {
                return this.GetType().Name;
            }
        }
        #endregion

        #region Scene loading
        private IEnumerator LoadMainSceneAsync(System.Action<bool> callback) {
            if (string.IsNullOrEmpty(this._mainSceneName)) {
                TimiDebug.LogErrorColor("Main scene not set", LogColor.red);
                callback.Invoke(false);
                yield break;
            }
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(this._mainSceneName, LoadSceneMode.Additive);
            while (!asyncOperation.isDone) {
                yield return null;
            }
            callback.Invoke(true);
        }
        #endregion
    }
}