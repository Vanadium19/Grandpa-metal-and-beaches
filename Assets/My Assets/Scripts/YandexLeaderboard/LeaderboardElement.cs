using TMPro;
using UnityEngine;

namespace GMB.YandexLeaderboard
{
    internal class LeaderboardElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _score;

        public void Initialize(string name, int rank, int score)
        {
            _rank.text = $"{rank}.";
            _name.text = name;
            _score.text = score.ToString();
        }
    }
}