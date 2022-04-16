using UnityEngine;

namespace Asteroids.Builder
{
    /// <summary>
    /// Класс для создание объекта через Строителя
    /// </summary>
    internal class GameObjectBuilder
    {
        protected GameObject _gameObject;

        #region Конструкторы
        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;
        #endregion

        #region Автосвойства
        /// <summary>При вызове Visual создаётся ИО, в к-рый можно закинуть картинку</summary>
        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        /// <summary>При вызове Physics создаётся ИО, к-рый может работать с физикой (ЖёсткоеТело, Коллайдер)</summary>
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);
        #endregion

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}
