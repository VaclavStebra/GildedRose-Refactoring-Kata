using System;

namespace csharp
{
    class AgedBrieItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            int increaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Min(50, item.Quality + increaseRate);
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
