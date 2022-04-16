namespace Yrok3
{
    /// <summary>Интерфейс для реализации конкретного типа Платформы</summary>
    public interface IPlatform
    {
        IInput Input { get; }   //ввод данных
        IWindow Window { get; } //вывод данных
    }
}
