using TMPro;
using UnityEngine;

internal class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;

    public void Initialize(string name, int rank, int score) => _info.text = $"{rank}. {name} {score}";
}
