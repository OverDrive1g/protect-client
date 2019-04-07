using System;

namespace ProtectLib.Storage
{
    public interface IStorage
    {
        /// <summary>
        /// Метод для инициализации хранилища
        /// </summary>
        void init();
        
        /// <summary>
        /// Метод для получение значения по его ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object getValue(string key);
        
        /// <summary>
        /// Получение списка всех значений и ключей
        /// </summary>
        void getAll();
        
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