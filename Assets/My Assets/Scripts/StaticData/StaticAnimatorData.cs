using UnityEngine;

namespace GMB.StaticData
{
    public static class StaticAnimatorData
    {
        public static readonly int Walking = Animator.StringToHash("IsWalking");
        public static readonly int CollectMoney = Animator.StringToHash("CollectMoney");
        public static readonly int NoMoney = Animator.StringToHash("NoMoney");
        public static readonly int Buy = Animator.StringToHash("Buy");
    }
}