namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Абстрактный класс стратегии
/// </summary>
public abstract class AbstractStrategy
{
    /// <summary>
    /// Перемещаемый обьект
    /// </summary>
    private IMoveableObject? _moveableObject;

    /// <summary>
    /// Статус перемещения
    /// </summary>
    private StrategyStatus _state = StrategyStatus.NotInit;

    /// <summary>
    /// Ширина поля
    /// </summary>
    protected int FieldWidth { get; private set; }

    /// <summary>
    /// Высота поля
    /// </summary>
    protected int FieldHeight { get; private set; }

    /// <summary>
    /// Получение статуса перемещения
    /// </summary>
    /// <returns></returns>
    public StrategyStatus GetStatus() => _state;

    /// <summary>
    /// Установка данных
    /// </summary>
    /// <param name="moveableObject">Перемещаемый обьект</param>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    public void SetData(IMoveableObject moveableObject, int width, int height)
    {
        if (moveableObject == null)
        {
            _state = StrategyStatus.NotInit;
            return;
        }

        _state = StrategyStatus.InProgress;
        _moveableObject = moveableObject;
        FieldWidth = width;
        FieldHeight = height;
    }

    /// <summary>
    /// Шаг перемещения
    /// </summary>
    public void MakeStep()
    {
        if (_state != StrategyStatus.InProgress)
        {
            return;
        }
        if (IsTargetDestination())
        {
            _state = StrategyStatus.Finish;
            return;
        }

        MoveToTarget();
    }

    /// <summary>
    /// Перемещение влево
    /// </summary>
    /// <returns>true - переместился, false - нет</returns>
    protected bool MoveLeft() => MoveTo(MovementDirection.Left);

    /// <summary>
    /// Перемещение вплаво
    /// </summary>
    /// <returns>true - переместился, false - нет</returns>
    protected bool MoveRight() => MoveTo(MovementDirection.Right);

    /// <summary>
    /// Перемещение вверх
    /// </summary>
    /// <returns>true - переместился, false - нет</returns>
    protected bool MoveUp() => MoveTo(MovementDirection.Up);

    /// <summary>
    /// Перемещение вниз
    /// </summary>
    /// <returns>true - переместился, false - нет</returns>
    protected bool MoveDown() => MoveTo(MovementDirection.Down);

    /// <summary>
    /// Получение параметров обьекта
    /// </summary>
    protected ObjectParameters? GetObjectParameters => _moveableObject?.GetObjectPosition;

    /// <summary>
    /// Шаг обьекта
    /// </summary>
    /// <returns></returns>
    protected int? GetStep()
    {
        if (_state != StrategyStatus.InProgress)
        {
            return null;
        }
        return _moveableObject?.GetStep;
    }

    /// <summary>
    /// Перемещение к цели
    /// </summary>
    protected abstract void MoveToTarget();

    /// <summary>
    /// Достигнута ли цель
    /// </summary>
    /// <returns></returns>
    protected abstract bool IsTargetDestination();

    /// <summary>
    /// Попытка перемещения в нужном направлении
    /// </summary>
    /// <param name="movementDirection"></param>
    /// <returns>true - переместился, false - нет</returns>
    private bool MoveTo(MovementDirection movementDirection)
    {
        if (_state != StrategyStatus.InProgress)
        {
            return false;
        }
        return _moveableObject?.TryMoveObject(movementDirection) ?? false;
    }
}
