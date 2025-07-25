using System.Collections;
using Agava.YandexGames;
using GMB.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMB.Settings
{
    internal sealed class SDKInitializer : MonoBehaviour
    {
        private void Awake() => YandexGamesSdk.CallbackLogging = true;

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene((int)SceneNames.Menu);
        }
    }
}