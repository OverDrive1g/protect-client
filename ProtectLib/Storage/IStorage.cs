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

        /// <summary>
        /// Установка нового значения в хранилища
        /// </summary>
        /// <param name="value"></param>
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