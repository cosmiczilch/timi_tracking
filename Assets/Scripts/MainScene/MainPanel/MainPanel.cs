using TimiShared.Debug;
using TimiShared.Loading;
using TimiShared.UI;
using UnityEngine;

namespace TimiTracking.MainScene {
    public class MainPanel : MonoBehaviour {
        [SerializeField] private Animator _animator;

        private const string kTriggerNameIntro = "Intro";
        private const string kTriggerNameExit  = "Exit";

        #region Static
        private const string kMainPanelPrefabName = "Prefabs/UI/MainPanel";
        public static void Present() {
            if (MainPanel.Instance != null) {
                TimiDebug.LogColor("Already loaded an instance of MainPanel", LogColor.green);
                MainPanel.Instance.Show();
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

        #region LifeCycle
        private void Awake() {
            this.ResetTriggers();
            MainPanelExitStateMachineBehaviour exitStateMachineBehaviour = this._animator.GetBehaviour<MainPanelExitStateMachineBehaviour>();
            if (exitStateMachineBehaviour != null) {
                exitStateMachineBehaviour.MainPanel = this;
            }
        }

        private void OnDestroy() {
            MainPanel.Instance = null;
        }

        private void Show() {
            this.gameObject.SetActive(true);
            MainPanel.Instance.SetTrigger(kTriggerNameIntro);
        }

        private void Dismiss() {
            this.SetTrigger(kTriggerNameExit);
        }

        private void OnDismissComplete() {
            this.gameObject.SetActive(false);
        }
        #endregion

        #region Event Handling
        public void OnCheckinButtonClicked() {
            this.Dismiss();
        }

        public void OnExitHideComplete() {
            this.OnDismissComplete();
        }
        #endregion

        private void SetTrigger(string triggerName) {
            if (this._animator != null) {
                this._animator.SetTrigger(triggerName);
            }
        }

        private void ResetTriggers() {
            if (this._animator != null) {
                this._animator.ResetTrigger(kTriggerNameIntro);
                this._animator.ResetTrigger(kTriggerNameExit);
            }
        }

    }
}