using ProjectContainerShip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectContainerShip.Drawnings;

public class DrawningShip
{

    /// <summary>
    /// Класс сущность
    /// </summary>
    public EntityShip? EntityShip { get; protected set; }

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
    protected int? _startPosX;

    /// <summary>
    /// Верхняя координата прорисовки контейнеровоза
    /// </summary>
    protected int? _startPosY;

    /// <summary>
    /// Ширина прорисовки контейнеровоза
    /// </summary>
    private readonly int _drawingShipWidth = 210;

    /// <summary>
    /// Высота прорисовки контейнеровоза
    /// </summary>
    private readonly int _drawingShipHeight = 130;

    /// <summary>
    /// Пустой конструктор 
    /// </summary>
    private DrawningShip()
    {
        _pictureWidth = null;
        _pictureHeight = null;
        _startPosX = null;
        _startPosY = null;
    }

    /// <summary>
    /// Конструктор 
    /// </summary>
    /// <param name="speed">Скорость контейнеровоза</param>
    /// <param name="weight">Вес контейнеровоза</param>
    /// <param name="bodyColor">Цвет контейнеровоза</param>
    public DrawningShip(int speed, double weight, Color bodyColor) : this()
    {
        EntityShip = new EntityShip(speed, weight, bodyColor);
    }

    /// <summary>
    /// Конструктор для наследников
    /// </summary>
    /// <param name="drawingShipWidth">Ширина прорисовки корабля</param>
    /// <param name="drawingShipHeight">Высота прорисовки корабля</param>
    protected DrawningShip(int drawingShipWidth, int drawingShipHeight) : this()
    {
        _drawingShipHeight = drawingShipHeight;
        _drawingShipWidth = drawingShipWidth;
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
        if (EntityShip == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return false;
        }
        switch (direction)
        {
            case DirectionType.Left:
                if (_startPosX.Value - EntityShip.Step > 0)
                {
                    _startPosX -= (int)EntityShip.Step;
                }
                return true;
            case DirectionType.Up:
                if (_startPosY.Value - EntityShip.Step > 0)
                {
                    _startPosY -= (int)EntityShip.Step;
                }
                return true;
            case DirectionType.Right:
                if (_startPosX.Value + _drawingShipWidth + EntityShip.Step < _pictureWidth)
                {
                    _startPosX += (int)EntityShip.Step;
                }
                return true;
            case DirectionType.Down:
                if (_startPosY.Value + _drawingShipHeight + EntityShip.Step < _pictureHeight)
                {
                    _startPosY += (int)EntityShip.Step;
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
    public virtual void DrawShip(Graphics g)
    {
        if (EntityShip == null || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }

        Pen pen = new(Color.Black);

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
        g.DrawLine(pen, _startPosX.Value, _startPosY.Value + 50, _startPosX.Value + 45, _startPosY.Value + 80);//носовая часть корпуса
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 80, _startPosX.Value + 175, _startPosY.Value + 80);//нижняя линия корпуса
        g.DrawLine(pen, _startPosX.Value, _startPosY.Value + 50, _startPosX.Value + 210, _startPosY.Value + 50);//верхняя линия корпуса
        g.DrawLine(pen, _startPosX.Value + 175, _startPosY.Value + 80, _startPosX.Value + 210, _startPosY.Value + 50);//задняя часть корпуса
        g.DrawRectangle(pen, _startPosX.Value + 180, _startPosY.Value, 20, 50);//рубка

        //Заливка корабля
        Brush bodyCol = new SolidBrush(EntityShip.BodyColor);
        Point bp1 = new(_startPosX.Value + 1, _startPosY.Value + 51);
        Point bp2 = new(_startPosX.Value + 45, _startPosY.Value + 80);
        Point bp3 = new(_startPosX.Value + 45, _startPosY.Value + 80);
        Point bp4 = new(_startPosX.Value + 175, _startPosY.Value + 80);
        Point bp5 = new(_startPosX.Value + 175, _startPosY.Value + 80);
        Point bp6 = new(_startPosX.Value + 210, _startPosY.Value + 50);
        Point bp7 = new(_startPosX.Value + 210, _startPosY.Value + 50);
        Point bp8 = new(_startPosX.Value + 1, _startPosY.Value + 51);
        Point[] curveBp = [bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8];
        g.FillPolygon(bodyCol, curveBp);
        g.FillRectangle(bodyCol, _startPosX.Value + 181, _startPosY.Value + 1, 19, 49);//рубка
        g.DrawLine(pen, _startPosX.Value + 50, _startPosY.Value + 55, _startPosX.Value + 50, _startPosY.Value + 65);//верт. линия якоря
        g.DrawLine(pen, _startPosX.Value + 45, _startPosY.Value + 60, _startPosX.Value + 55, _startPosY.Value + 60);//верхняя гориз. линия якоря
        g.DrawLine(pen, _startPosX.Value + 47, _startPosY.Value + 65, _startPosX.Value + 53, _startPosY.Value + 65);//нижняя гориз. линия якоря
        #endregion
    }
}
