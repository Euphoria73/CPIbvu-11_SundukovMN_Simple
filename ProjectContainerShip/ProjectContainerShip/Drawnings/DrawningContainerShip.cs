using ProjectContainerShip.Entities;

namespace ProjectContainerShip.Drawnings;

/// <summary>
/// Отрисовка сущности контейнеровоза
/// </summary>
public class DrawningContainerShip : DrawningShip
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость контейнеровоза</param>
    /// <param name="weight">Вес контейнеровоза</param>
    /// <param name="bodyColor">Цвет контейнеровоза</param>
    /// <param name="additionalColor">Цвет дополнительных элементов</param>
    /// <param name="containers">Наличие контейнеров (опция)</param>
    /// <param name="floorContainers">Наличие 2 ряда контейнеров (опция)</param>
    /// <param name="crane">Наличие крана (опция)</param>
    public DrawningContainerShip(int speed, double weight, Color bodyColor, Color additionalColor, bool containers, bool floorContainers, bool crane) : base(210, 85)
    {
        EntityShip = new EntityConteinerShip(speed, weight, bodyColor, additionalColor, containers, floorContainers, crane);
    }

    /// <summary>
    /// Прорисовка контейнеровоза
    /// </summary>
    /// <param name="g">графическое представление</param>
    public override void DrawShip(Graphics g)
    {
        if (EntityShip is not EntityConteinerShip conteinerShip || !_startPosX.HasValue || !_startPosY.HasValue)
        {
            return;
        }

        Pen pen = new(Color.Black);
        Brush additionalBrush = new SolidBrush(conteinerShip.AdditionalColor);

        base.DrawShip(g);
        _startPosY -= 5;

        #region Прорисовка крана (опция)
        if (conteinerShip.Crane)
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
        if (conteinerShip.Containers)
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
            if (conteinerShip.FloorContainers)
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

        _startPosY += 5;
    }
}
