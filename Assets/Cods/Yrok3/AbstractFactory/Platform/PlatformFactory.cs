using UnityEngine;

namespace Yrok3
{
    /// <summary>Фабрика по выбору платформы</summary>
    internal sealed class PlatformFactory
    {
        private readonly InputFactory _inputFactory;    //фабрика для создания ввода данных
        private readonly WindowFactory _windowFactory;  //фабрика для создания вывода данных

        public PlatformFactory()
        {
            _inputFactory = new InputFactory();
            _windowFactory = new WindowFactory();
        }

        //создание управления для новой платформы
        public Platform Create(RuntimePlatform platform)
        {
            return new Platform(_inputFactory.CreateInput(platform), _windowFactory.CreateWindow(platform));
        }
    }
}
