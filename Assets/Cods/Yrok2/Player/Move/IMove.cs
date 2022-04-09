namespace Yrok2
{
    public interface IMove
    {
        /// <summary>Скорость</summary>
        float Speed { get; }

        /// <summary>Перемещение объекта</summary>
        void Move(float horizontal, float vertical);
    }
}
