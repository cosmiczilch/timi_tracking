using UnityEngine;

namespace TimiTracking.MainScene {
    public class MainPanelExitStateMachineBehaviour : StateMachineBehaviour {

        public MainPanel MainPanel {
            get; set;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            this.MainPanel.OnExitHideComplete();
        }
    }
}