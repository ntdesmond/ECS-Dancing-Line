using CoinCounter;

namespace System.Utils
{
    public static class CoinCounterActions
    {
        public static void Update(UnityEngine.UI.Text text, CoinCount count)
        {
            text.text = $"{count.collected}/{count.total}";
        }
    }
}