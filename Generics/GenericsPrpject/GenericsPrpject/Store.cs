namespace GenericsPrpject
{
    public class Store<T> where T : IHasId
    {
        private readonly Dictionary<int, T> _items = new();

        public void Add(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new InvalidOperationException($"An item with Id '{item.Id}' already exists in the store.");
            }

            _items.Add(item.Id, item);
        }

        public T? GetById(int id)
        {
            if (_items.TryGetValue(id, out var item))
            {
                return item;
            }

            return default;
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return _items.Values;
        }

        public bool Remove(int id)
        {
            return _items.Remove(id);
        }
    }
}