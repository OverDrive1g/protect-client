namespace ProtectLib.Storage
{
    public interface IStorage<T>
    {
        /// <summary>
        /// Метод для инициализации хранилища
        /// </summary>
        void init();
        
        /// <summary>
        /// Получение списка всех значений и ключей
        /// </summary>
        T get();

        void set(T value);
        
        /// <summary>
        /// Обновляет все значение из хранилища
        /// </summary>
        void update();
        
        /// <summary>
        /// Сохраняет все значения в хранилища
        /// </summary>
        void save();

    }
}