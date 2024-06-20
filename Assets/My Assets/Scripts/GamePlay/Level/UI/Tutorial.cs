using GMB.Settings;
using GMB.UI;
using UnityEngine;

namespace GMB.GamePlay.Level
{
    internal class Tutorial : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private Menu _menu;
        [SerializeField] private GameObject _tutorialPanel;
        [SerializeField] private GameObject[] _closablePanels;

        private void Start()
        {
            if (GameSaver.IsTutorialCompleted(_name) == false)
                TurnOnTutorial();

            enabled = false;
        }

        private void TurnOnTutorial()
        {
            ClosePanels();
            _tutorialPanel.SetActive(true);
            _menu.StopTime();
            GameSaver.SaveTutorial(_name);
        }

        private void ClosePanels()
        {
            if (_closablePanels.Length == 0)
                return;

            foreach (var closablePanel in _closablePanels)
                closablePanel.SetActive(false);
        }
    }
}