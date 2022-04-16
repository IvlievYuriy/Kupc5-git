namespace Yrok3
{
    /// <summary>Ввод/вывод данных для конктетного типа платформы</summary>
    internal sealed class Platform : IPlatform
    {
        public IInput Input { get; }
        public IWindow Window { get; }
        public Platform(IInput input, IWindow window)
        {
            Input = input;
            Window = window;
        }
    }
}
