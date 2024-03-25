using System.Collections.Generic;
using UnityEngine;

internal class GoodsInstaller : MonoBehaviour
{
    [SerializeField] private List<Good> _goodPrefabs;
    [SerializeField] private Transform _goodsContent;
    [SerializeField] private AudioSource _buttonAudio;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Transform _decor;

    private void Awake()
    {
        foreach (var good in _goodPrefabs)        
            Create(good);        
    }

    private void Create(Good good)
    {
        var goodPicture = _decor.Find(good.Name);
        var newGood = Instantiate(good, _goodsContent);

        newGood.Initialize(_wallet, goodPicture, _buttonAudio);

        if (newGood.IsSold)
            newGood.Install();
    }
}
