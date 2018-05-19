using System;

namespace csharp
{
    class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            int decreaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Max(0, item.Quality - decreaseRate);
            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            return HasPassed(item) ? 2 : 1;
        }

        private bool HasPassed(Item item)
        {
            return item.SellIn == 0;
        }
    }
}
