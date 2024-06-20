using Agava.YandexGames;
using UnityEngine;

namespace GMB.Settings
{
    internal class GameTuner : MonoBehaviour
    {
        private void Awake()
        {
            if (GameSaver.IsGameConfigured == false)
                GameSaver.SetDefaultSettings();
        }

        private void Start()
        {
            AudioListener.volume = GameSaver.Volume;
            YandexGamesSdk.GameReady();
        }
    }
}