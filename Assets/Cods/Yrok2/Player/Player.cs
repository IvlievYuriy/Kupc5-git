using UnityEngine;

namespace Yrok2
{
    /// <summary>
    /// Персонаж
    /// Вешаем на ИО - Player
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]   //добавляем на объект Жёсткое Тело
    [RequireComponent(typeof(BoxCollider))]    //добавляем на объект Коллайдер
    internal sealed class Player : MonoBehaviour
    {
        #region Поля

        #region Текущие характеристики персонажа
        [SerializeField] private float _currentSpeed;          //текущая скорость
        [SerializeField] private float _currentAcceleration;   //текущее ускорение
        [SerializeField] private float _currentHP;             //текущее здоровье
        #endregion

        #region Компоненты персонажа
        private BoxCollider _collider;
        private Rigidbody _rb;
        #endregion

        #region Стрельба
        [SerializeField] private Transform _barrel;     //позиция, откуда вылетает снаряд        
        [SerializeField] private IBullets _bullet;      //Характеристики снаряда
        [SerializeField] private IFire fire;
        #endregion

        private Camera _camera;         //камера 
        private Ship _ship;             //корабль
        #endregion


        private void Start()
        {
            _camera = Camera.main;

            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();

            #region Присвоение Персонажу текущих характеристик
            IDataShip _dataShip = new DataShip();
            _currentSpeed = _dataShip.Speed;
            _currentAcceleration = _dataShip.Acceleration;
            _currentHP = _dataShip.HP;
            #endregion

            #region Перемещение/Вращение Персонажа
            var moveTransform = new AccelerationMove(transform, _rb, _currentSpeed, _currentAcceleration);
            var rotation = new RotationShip(transform);

            _ship = new Ship(moveTransform, rotation);
            #endregion

            #region Стрельба Персонажа
            _bullet = new Bullets();
            fire = new Fire(_bullet, _barrel);
            #endregion
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

            _ship.Rotation(direction);

            //считывание ввода
            _ship.Move(Input.GetAxis(AxisManager.HORIZONTAL), Input.GetAxis(AxisManager.VERTICAL));
        }

        private void FixedUpdate()
        {
            GetKey();
            GetButtom();
        }

        #region Методы
        #region Клавиши клавиатуры
        /// <summary>Действия с клавишами клавиатуры </summary>
        private void GetKey()
        {
            //вкл. ускорение
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();                
            }

            //выкл. ускорение
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }
        #endregion

        #region Клавиши мыши
        /// <summary>Действия с клавишами мыши </summary>
        private void GetButtom()
        {
            //стрельба
            if (Input.GetButtonDown(AxisManager.FIRE1))
            {
                fire.Fire1();
            }
        }
        #endregion
        #endregion

        #region Коллизия
        private void OnCollisionEnter2D(Collision2D other)
        {
            //обработка урона
            if (_currentHP <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _currentHP--;
            }
        }
        #endregion
    }

    #region
    #endregion
}