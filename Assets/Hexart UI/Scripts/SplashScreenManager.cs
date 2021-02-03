using UnityEngine;

namespace Michsky.UI.Hexart
{
    public class SplashScreenManager : MonoBehaviour
    {
        [Header("RESOURCES")]
        public GameObject splashScreen;
        public GameObject mainPanels;
        public GameObject homePanel;
        private Animator mainPanelsAnimator;
        private Animator homePanelAnimator;

        [Header("SETTINGS")]
        public bool disableSplashScreen;

        void Start()
        {
            if (disableSplashScreen == true)
            {
                splashScreen.SetActive(false);
                mainPanels.SetActive(true);

                mainPanelsAnimator = mainPanels.GetComponent<Animator>();
                mainPanelsAnimator.Play("Main Panel Opening");
                homePanelAnimator = homePanel.GetComponent<Animator>();
                homePanelAnimator.Play("MP Fade-in Start");
            }

            else
            {
                splashScreen.SetActive(true);
                mainPanels.SetActive(false);
            }
        }
    }
}