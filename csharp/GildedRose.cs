using System.Collections.Generic;
using csharp.ItemUpdaters;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                IItemUpdater itemUpdater = ItemUpdaterFactory.GetItemUpdater(Items[i].Name);
                itemUpdater.Update(Items[i]);
            }
        }
    }
}
