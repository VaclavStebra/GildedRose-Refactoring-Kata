using System;

namespace csharp.ItemUpdaters
{
    class ConjuredItemUpdater : AbstractItemUpdater
    {
        public override void Update(Item item)
        {
            int decreaseRate = GetQualityChangeRate(item);
            item.Quality = Math.Max(0, item.Quality - decreaseRate);
            item.SellIn--;
        }

        private int GetQualityChangeRate(Item item)
        {
            return HasPassed(item) ? 4 : 2;
        }
    }
}
