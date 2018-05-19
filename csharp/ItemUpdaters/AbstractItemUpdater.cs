namespace csharp.ItemUpdaters
{
    abstract class AbstractItemUpdater : IItemUpdater
    {
        public abstract void Update(Item item);

        protected bool HasPassed(Item item)
        {
            return item.SellIn <= 0;
        }
    }
}
