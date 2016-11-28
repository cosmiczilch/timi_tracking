using TimiShared.Debug;
using TimiShared.Loading;
using TimiShared.UI;
using UnityEngine;

namespace TimiTracking.MainScene {
    public class EmoticonPanel : MonoBehaviour {

        [SerializeField] private Animator _animator;

        private const string kTriggerNameIntro = "Intro";
        private const string kTriggerNameExit  = "Exit";

        #region Static
        private const string kEmoticonPanelPrefabName = "Prefabs/UI/EmoticonPanel";
        public static void Present() {
            if (EmoticonPanel.Instance != null) {
                TimiDebug.LogColor("Already loaded an instance of EmoticonPanel", LogColor.green);
                EmoticonPanel.Instance.Show();
                return;
            }
            PrefabLoader.Instance.InstantiateAsynchronous(kEmoticonPanelPrefabName, UIRootView.Instance.MainCanvas.transform, (loadedGO) => {
                EmoticonPanel.Instance = loadedGO.GetComponent<EmoticonPanel>();
                if (EmoticonPanel.Instance == null) {
                    TimiDebug.LogWarningColor("Cannot find " + typeof(EmoticonPanel).Name + " on loaded prefab", LogColor.red);
                }
            });
        }

        public static EmoticonPanel Instance {
            get; private set;
        }
        #endregion

        #region LifeCycle
        private void Awake() {
            this.ResetTriggers();
            EmoticonPanelExitStateMachineBehaviour exitStateMachineBehaviour = this._animator.GetBehaviour<EmoticonPanelExitStateMachineBehaviour>();
            if (exitStateMachineBehaviour != null) {
                exitStateMachineBehaviour.EmoticonPanel = this;
            }
        }

        private void OnDestroy() {
            EmoticonPanel.Instance = null;
        }

        private void Show() {
            this.gameObject.SetActive(true);
            EmoticonPanel.Instance.SetTrigger(kTriggerNameIntro);
        }

        private void Dismiss() {
            this.SetTrigger(kTriggerNameExit);
        }

        private void OnDismissComplete() {
            this.gameObject.SetActive(false);
        }
        #endregion

        public void OnExitHideComplete() {
            this.OnDismissComplete();
        }

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