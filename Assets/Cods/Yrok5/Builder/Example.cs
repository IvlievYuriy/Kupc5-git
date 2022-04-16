using UnityEngine;

namespace Asteroids.Builder
{
    /// <summary>
    /// Вешаем на Стартер
    /// </summary>
    internal sealed class Example : MonoBehaviour
    {
        private const string PREFAB_LOTUS = "Sprites/LotusFlower"; //убираем все строковые переменные в константы
        
        [SerializeField] private Sprite _sprite;    //картинка для отображения на дисплее        
        [SerializeField] private int _massa = 1;    //масса ИО

        private void Start()
        {
            #region Создаём задний план из примитива
            GameObject backGround = GameObject.CreatePrimitive(PrimitiveType.Plane);
            backGround.transform.position = new Vector3(0,-3,0);   //задаём координаты
            backGround.AddComponent<BoxCollider>();
            #endregion

            var gameObjectBuilder = new GameObjectBuilder();    //создаём ИО через Строителя

            _sprite = Resources.Load<Sprite>(PREFAB_LOTUS);

            GameObject player = gameObjectBuilder.Visual        //
                                                 .Name("ExampleObject")
                                                 .Sprite(_sprite)
                                                 .Physics
                                                 .Rigidbody2D(_massa)
                                                 .BoxCollider2D();

            player.GetComponent<Rigidbody2D>().gravityScale = 0;   //убираем гравитацию
            player.transform.position = new Vector2(0,0);       //задаём координаты
        }
    }
}
