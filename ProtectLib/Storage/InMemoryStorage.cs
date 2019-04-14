namespace ProtectLib.Storage
{
    public class InMemoryStorage<T> : IStorage<T>
    {
        private T _payload;

        public void init()
        {
            // нет необходимости реализовывать, так как все в памяти
        }

        public T get()
        {
            return _payload;
        }

        public void set(T value)
        {
            _payload = value;
        }

        public void update()
        {
            // нет необходимости реализовывать, так как все в памяти
        }

        public void save()
        {
            // нет необходимости реализовывать, так как все в памяти
        }
    }
}