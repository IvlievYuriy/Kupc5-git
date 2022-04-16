using UnityEngine;

namespace Asteroids.Builder
{
    #region
    #endregion

    /// <summary>
    /// Конкретный строитель для визуала
    /// </summary>
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject)
        { 
        }

        #region Методы
        /// <summary>Вешаем на ИО БоксКоллайдер2D </summary>
        public GameObjectPhysicsBuilder BoxCollider2D()
        {
            GetOrAddComponent<BoxCollider2D>();
            return this;
        }

        /// <summary>Вешаем на ИО ЖёсткоеТело2D определённой массы</summary>
        public GameObjectPhysicsBuilder Rigidbody2D(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }

        /// <summary>Навешиваем на ИО любой компонент в Инспекторе</summary>
        private T GetOrAddComponent<T>() where T : Component
        {
            //Присваиваем переменной ссылку на компонент ИО
            var result = _gameObject.GetComponent<T>();

            //Если такого компонента нет на ИО,
            if (!result)
            {   //то
                result = _gameObject.AddComponent<T>(); //создаем компонент нужного типа у ИО
            }

            return result;
        }
        #endregion
    }
}
