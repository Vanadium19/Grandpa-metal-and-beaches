using System.Collections.Generic;
using UnityEngine;

internal class GoodsInstaller : MonoBehaviour
{
    [SerializeField] private List<Good> _goodPrefabs;
    [SerializeField] private Transform _goodsContent;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        foreach (var good in _goodPrefabs)        
            Create(good);        
    }

    private void Create(Good good)
    {
        var newGood = Instantiate(good, _goodsContent);

        newGood.Initialize(_wallet, _canvas);

        if (newGood.IsSold)
            newGood.Create();
    }
}
