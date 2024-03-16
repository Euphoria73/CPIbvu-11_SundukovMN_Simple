namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Перечисление статуса стратегии
/// </summary>
public enum StrategyStatus
{
    /// <summary>
    /// Готово к запуску
    /// </summary>
    NotInit,

    /// <summary>
    /// Выполняется
    /// </summary>
    InProgress,

    /// <summary>
    /// Завершено
    /// </summary>
    Finish
}
