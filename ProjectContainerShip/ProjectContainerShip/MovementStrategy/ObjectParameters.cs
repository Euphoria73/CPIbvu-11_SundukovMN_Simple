namespace ProjectContainerShip.MovementStrategy;

/// <summary>
/// Класс, отвечающий за параметры обьекта
/// </summary>
public class ObjectParameters
{
    /// <summary>
    /// Координата Х
    /// </summary>
    private readonly int _x;

    /// <summary>
    /// Координата У
    /// </summary>
    private readonly int _y;

    /// <summary>
    /// Ширина обьекта
    /// </summary>
    private readonly int _width;

    /// <summary>
    /// Высота обьекта
    /// </summary>
    private readonly int _height;

    /// <summary>
    /// Левая граница
    /// </summary>
    public int LeftBorder => _x;

    /// <summary>
    /// Верхняя граница
    /// </summary>
    public int TopBorder => _y;

    /// <summary>
    /// Правая граница
    /// </summary>
    public int RightBorder => _x + _width;

    /// <summary>
    /// Нижняя граница
    /// </summary>
    public int BottomBorder => _y + _height;

    /// <summary>
    /// Середина обьекта по горизонтали
    /// </summary>
    public int ObjectMiddleHorizontal => _x + _width / 2;

    /// <summary>
    /// Середина обьекта по вертикали
    /// </summary>
    public int OblectMiddleVertical => _y + _height / 2;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="x">Координата Х</param>
    /// <param name="y">Координата У</param>
    /// <param name="width"> Ширина обьекта</param>
    /// <param name="height">Высота обьекта</param>
    public ObjectParameters(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }
}
