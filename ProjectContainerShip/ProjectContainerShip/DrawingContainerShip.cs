namespace ProjectContainerShip;

/// <summary>
/// Отрисовка сущности контейнеровоза
/// </summary>
public class DrawingContainerShip
{
    /// <summary>
    /// Класс сущность
    /// </summary>
    public EntityConteinerShip? EntityConteinerShip { get; private set; }

    /// <summary>
    /// Ширина окна
    /// </summary>
    public int? _pictureWidth;

    /// <summary>
    /// Высота окна
    /// </summary>
    public int? _pictureHeight;

    /// <summary>
    /// Левая координата прорисовки контейнеровоза
    /// </summary>
    private int? _startPosX;

    /// <summary>
    /// Верхняя координата прорисовки контейнеровоза
    /// </summary>
    private int? _startPosY;

    /// <summary>
    /// Ширина прорисовки контейнеровоза
    /// </summary>
    private readonly int _drawingShipWidth = 210;

    /// <summary>
    /// Высота прорисовки контейнеровоза
    /// </summary>
    private readonly int _drawingShipHeight = 85;
    /// <summary>
    /// Наличие этажей контейнера (опция)
    /// </summary>
    private bool _floorContainers;
    /// <summary>
    /// Инициализация  полей обьекта-класса контейнеровоза
    /// </summary>
    /// <param name="speed">Скорость контейнеровоза</param>
    /// <param name="weight">Вес контейнеровоза</param>
    /// <param name="bodyColor">Цвет контейнеровоза</param>
    /// <param name="additionalColor">Цвет дополнительных элементов</param>
    /// <param name="containers">Наличие контейнеров (опция)</param>
    /// <param name="floorContainers">Наличие 2 ряда контейнеров (опция)</param>
    /// <param name="crane">Наличие крана (опция)</param>
    /// 
    public void Init(int speed, double weight, Color bodyColor, Color additionalColor, bool containers, bool floorContainers, bool crane)
    {
        EntityConteinerShip = new EntityConteinerShip();
        EntityConteinerShip.Init(speed, weight, bodyColor, additionalColor, containers, floorContainers, crane);
        _pictureWidth = null;
        _pictureHeight = null;
        _startPosX = null;
        _startPosY = null;
        _floorContainers = floorContainers;
    }

    /// <summary>
    /// Установка границ поля
    /// </summary>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    /// <returns>true-границы заданы, false-проверка не пройдена, разместить объект нельзя</returns>
    public bool SetPictureSize(int width, int height)
    {
        if (width < _drawingShipWidth || height < _drawingShipHeight)
        {
            _pictureWidth = _drawingShipWidth;
            _pictureHeight = _drawingShipHeight;
            return true;
        }
        else
        {
            _pictureWidth = width;
            _pictureHeight = height;
            return true;
        }
    }

    /// <summary>
    /// Установка позиции
    /// </summary>
    /// <param name="x">Координата Х</param>
    /// <param name="y">Координата У</param>
    public void SetPosition(int x, int y)
    {
        if (!_pictureHeight.HasValue || !_pictureWidth.HasValue)
        {
            return;
        }

        if (x + _drawingShipWidth > _pictureHeight.Value || y + _drawingShipHeight > _pictureWidth.Value)
        {
            _startPosX = 0;
            _startPosY = 0;
        }
        else
        {
            _startPosX = x;
            _startPosY = y;
        }
    }

    /// <summary>
    /// Изменение направления контейнеровоза
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public bool MoveShip(DirectionType direction)
    {
        if (EntityConteinerShip == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return false;
        }
        switch (direction)
        {
            case DirectionType.Left:
                if (_startPosX.Value - EntityConteinerShip.Step > 0)
                {
                    _startPosX -= (int)EntityConteinerShip.Step;
                }
                return true;
            case DirectionType.Up:
                if (_startPosY.Value - EntityConteinerShip.Step > 0)
                {
                    _startPosY -= (int)EntityConteinerShip.Step;
                }
                return true;
            case DirectionType.Right:
                if (_startPosX.Value + _drawingShipWidth + EntityConteinerShip.Step < _pictureWidth)
                {
                    _startPosX += (int)EntityConteinerShip.Step;
                }
                return true;
            case DirectionType.Down:
                if (_startPosY.Value + _drawingShipHeight + EntityConteinerShip.Step < _pictureHeight)
                {
                    _startPosY += (int)EntityConteinerShip.Step;
                }
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Прорисовка объекта
    /// </summary>
    /// <param name="g">графическое представление </param>
    public void DrawShip(Graphics g)
    {
        if (EntityConteinerShip == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }

        Pen pen = new(Color.Black);
        Brush additionalBrush = new SolidBrush(EntityConteinerShip.AdditionalColor);

        #region Прорисовка корабля из шаблона задания
        /*
        //Прорисовка корабля из шаблона задания
        g.DrawLine(pen, _startPosX.Value + 10, _startPosY.Value + 25, _startPosX.Value + 45, _startPosY.Value + 55);//носовая часть корпуса
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 55, _startPosX.Value + 175, _startPosY.Value + 55);//нижняя линия корпуса
        g.DrawLine(pen, _startPosX.Value + 10, _startPosY.Value + 25, _startPosX.Value + 210, _startPosY.Value + 25);//верхняя линия корпуса
        g.DrawLine(pen, _startPosX.Value + 175, _startPosY.Value + 55, _startPosX.Value + 210, _startPosY.Value + 25);//задняя часть корпуса
        g.DrawRectangle(pen, _startPosX.Value + 60, _startPosY.Value + 5, 120, 20);//рубка
        g.DrawLine(pen, _startPosX.Value + 50, _startPosY.Value + 30, _startPosX.Value + 50, _startPosY.Value + 40);//верт. линия якоря
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 35, _startPosX.Value + 55, _startPosY.Value + 35);//верхняя гориз. линия якоря
        g.DrawLine(pen, _startPosX.Value + 47, _startPosY.Value + 40, _startPosX.Value + 53, _startPosY.Value + 40);//нижняя гориз. линия якоря
        */
        #endregion

        #region Прорисовка корабля по варианту "Контейнеровоз"
        g.DrawLine(pen, _startPosX.Value, _startPosY.Value + 55, _startPosX.Value + 45, _startPosY.Value + 85);//носовая часть корпуса
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 85, _startPosX.Value + 175, _startPosY.Value + 85);//нижняя линия корпуса
        g.DrawLine(pen, _startPosX.Value, _startPosY.Value + 55, _startPosX.Value + 210, _startPosY.Value + 55);//верхняя линия корпуса
        g.DrawLine(pen, _startPosX.Value + 175, _startPosY.Value + 85, _startPosX.Value + 210, _startPosY.Value + 55);//задняя часть корпуса
        g.DrawRectangle(pen, _startPosX.Value + 180, _startPosY.Value + 5, 20, 50);//рубка

        //Заливка корабля
        Brush bodyCol = new SolidBrush(EntityConteinerShip.BodyColor);
        Point bp1 = new(_startPosX.Value + 1, _startPosY.Value + 56);
        Point bp2 = new(_startPosX.Value + 45, _startPosY.Value + 85);
        Point bp3 = new(_startPosX.Value + 45, _startPosY.Value + 85);
        Point bp4 = new(_startPosX.Value + 175, _startPosY.Value + 85);
        Point bp5 = new(_startPosX.Value + 175, _startPosY.Value + 85);
        Point bp6 = new(_startPosX.Value + 210, _startPosY.Value + 55);
        Point bp7 = new(_startPosX.Value + 210, _startPosY.Value + 55);
        Point bp8 = new(_startPosX.Value + 1, _startPosY.Value + 56);
        Point[] curveBp = [bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8];
        g.FillPolygon(bodyCol, curveBp);
        g.FillRectangle(bodyCol, _startPosX.Value + 181, _startPosY.Value + 6, 19, 49);//рубка
        g.DrawLine(pen, _startPosX.Value + 50, _startPosY.Value + 60, _startPosX.Value + 50, _startPosY.Value + 70);//верт. линия якоря
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 65, _startPosX.Value + 55, _startPosY.Value + 65);//верхняя гориз. линия якоря
        g.DrawLine(pen, _startPosX.Value + 47, _startPosY.Value + 70, _startPosX.Value + 53, _startPosY.Value + 70);//нижняя гориз. линия якоря
        #endregion

        #region Прорисовка крана (опция)
        if (EntityConteinerShip.Crane)
        {
            g.DrawRectangle(pen, _startPosX.Value + 100, _startPosY.Value + 15, 5, 40);//стойка крана
            g.DrawRectangle(pen, _startPosX.Value + 50, _startPosY.Value + 15, 50, 2);//плечо крана
            g.DrawRectangle(pen, _startPosX.Value + 50, _startPosY.Value + 15, 1, 10);//плечо крана
            g.FillRectangle(additionalBrush, _startPosX.Value + 101, _startPosY.Value + 16, 4, 39);//стойка крана
            g.FillRectangle(additionalBrush, _startPosX.Value + 51, _startPosY.Value + 16, 49, 2);//плечо крана
            g.FillRectangle(additionalBrush, _startPosX.Value + 51, _startPosY.Value + 16, 1, 9);//плечо крана
            //Прорисовка крюка
            Point cp1 = new(_startPosX.Value + 50, _startPosY.Value + 25);
            Point cp2 = new(_startPosX.Value + 53, _startPosY.Value + 28);
            Point cp3 = new(_startPosX.Value + 53, _startPosY.Value + 31);
            Point cp4 = new(_startPosX.Value + 50, _startPosY.Value + 34);
            Point cp5 = new(_startPosX.Value + 47, _startPosY.Value + 31);
            Point[] curveCp = [cp1, cp2, cp3, cp4, cp5];
            g.DrawCurve(pen, curveCp);
        }
        #endregion

        #region Прорисовка контейнеров (опция)
        if (EntityConteinerShip.Containers)
        {
            //нижний ряд контейнеров 
            g.DrawRectangle(pen, _startPosX.Value + 33, _startPosY.Value + 48, 30, 7);//контейнер 1
            g.DrawRectangle(pen, _startPosX.Value + 65, _startPosY.Value + 48, 30, 7);//контейнер 2
            g.DrawRectangle(pen, _startPosX.Value + 110, _startPosY.Value + 48, 30, 7);//контейнер 3
            g.DrawRectangle(pen, _startPosX.Value + 142, _startPosY.Value + 48, 30, 7);//контейнер 4
            //заливка
            g.FillRectangle(additionalBrush, _startPosX.Value + 34, _startPosY.Value + 49, 29, 6);//контейнер 1
            g.FillRectangle(additionalBrush, _startPosX.Value + 66, _startPosY.Value + 49, 29, 6);//контейнер 2
            g.FillRectangle(additionalBrush, _startPosX.Value + 111, _startPosY.Value + 49, 29, 6);//контейнер 3
            g.FillRectangle(additionalBrush, _startPosX.Value + 143, _startPosY.Value + 49, 29, 6);//контейнер 4

            //верхний ряд контейнеров (доп.опция)
            if (_floorContainers)
            {
                g.DrawRectangle(pen, _startPosX.Value + 33, _startPosY.Value + 40, 30, 7);//контейнер 5
                g.DrawRectangle(pen, _startPosX.Value + 65, _startPosY.Value + 40, 30, 7);//контейнер 6
                g.DrawRectangle(pen, _startPosX.Value + 110, _startPosY.Value + 40, 30, 7);//контейнер 7
                g.DrawRectangle(pen, _startPosX.Value + 142, _startPosY.Value + 40, 30, 7);//контейнер 8
                //заливка
                g.FillRectangle(additionalBrush, _startPosX.Value + 34, _startPosY.Value + 41, 29, 6);//контейнер 5
                g.FillRectangle(additionalBrush, _startPosX.Value + 66, _startPosY.Value + 41, 29, 6);//контейнер 6
                g.FillRectangle(additionalBrush, _startPosX.Value + 111, _startPosY.Value + 41, 29, 6);//контейнер 7
                g.FillRectangle(additionalBrush, _startPosX.Value + 143, _startPosY.Value + 41, 29, 6);//контейнер 8
            }
        }
        #endregion
    }
}
