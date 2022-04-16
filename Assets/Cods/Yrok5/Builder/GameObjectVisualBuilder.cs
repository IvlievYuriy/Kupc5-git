﻿using UnityEngine;

namespace Asteroids.Builder
{
    /// <summary>
    /// Конкретный строитель для визуала
    /// </summary>
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        #region Конструктор
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject)
        { 
        }
        #endregion

        #region Методы
        /// <summary>Присваиваем объекту Имя </summary>
        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        /// <summary>Присваиваем объекту Картинку для отображения на дисплее </summary>
        public GameObjectVisualBuilder Sprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
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
