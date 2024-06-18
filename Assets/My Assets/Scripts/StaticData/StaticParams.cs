using UnityEngine;

public static class StaticParams
{
    public static class AnimatorNames
    {
        public static readonly int Walking = Animator.StringToHash("IsWalking");
        public static readonly int CollectMoney = Animator.StringToHash("CollectMoney");
        public static readonly int NoMoney = Animator.StringToHash("NoMoney");
        public static readonly int Buy = Animator.StringToHash("Buy");
    }

    public static class GameNames
    {
        public static readonly string Money = "Money";
        public static readonly string Weight = "Weight";
        public static readonly string CurrentWeight = "CurrentWeight";

        public static readonly string Level = "Level";
        public static readonly string Tutorial = "Tutorial";
        public static readonly string Volume = "Volume";
        public static readonly string Settings = "Settings";

        public static readonly string Bag = "Bag";
        public static readonly string Speed = "Speed";
        public static readonly string ScrapCollector = "ScrapCollector";
    }
}