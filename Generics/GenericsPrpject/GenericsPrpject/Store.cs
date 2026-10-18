namespace GenericsPrpject
{

    public class Store<T>
    {
        private readonly List<T> _items = new();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public T? GetById(int id)
        {
            foreach (var item in _items)
            {
                // الكومبايلر في خطأ هنا ولن يترجم الكود
                if (item.Id == id)
                    return item;
            }

            return default;
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public bool Remove(int id)
        {
            for (var i = 0; i < _items.Count; i++)
            {
                // خطأ كومبايلر هنا برضو لنفس السبب
                if (_items[i].Id == id)
                {
                    _items.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }
}