namespace ProjectContainerShip;

public partial class FormContainerShip : Form
{
    /// <summary>
    /// Вызов класса прорисовки сущности "Контейнеровоз"
    /// </summary>
    private DrawingContainerShip? _drawingContainerShip;
    public FormContainerShip()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Работа кнопки "Создать"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        Random rnd = new();

        _drawingContainerShip = new DrawingContainerShip();

        _drawingContainerShip.Init(rnd.Next(100, 300), rnd.Next(1000, 3000),
            Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)),
            Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)),
            Convert.ToBoolean(rnd.Next(0, 2)), Convert.ToBoolean(rnd.Next(0, 2)), Convert.ToBoolean(rnd.Next(0, 2)));
        _drawingContainerShip.SetPictureSize(pictureBoxContainerShip.Width, pictureBoxContainerShip.Height);
        _drawingContainerShip.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100));

        Draw();
    }
    /// <summary>
    /// Действие при нажатии кнопки перемещения
    /// </summary>
    /// <param name="sender">кнопка перемещения</param>
    /// <param name="e"></param>
    private void ButtonMove_Click(object sender, EventArgs e)
    {
        if (_drawingContainerShip == null)
        {
            return;
        }

        string buttonName = ((Button)sender)?.Name ?? string.Empty;
        bool result = false;
        switch (buttonName)
        {
            case "buttonUp":
                result = _drawingContainerShip.MoveShip(DirectionType.Up);
                break;
            case "buttonDown":
                result = _drawingContainerShip.MoveShip(DirectionType.Down);
                break;
            case "buttonLeft":
                result = _drawingContainerShip.MoveShip(DirectionType.Left);
                break;
            case "buttonRight":
                result = _drawingContainerShip.MoveShip(DirectionType.Right);
                break;
        }

        if (result)
        {
            Draw();
        }
    }
    /// <summary>
    /// Отображение сущности на экране
    /// </summary>
    private void Draw()
    {
        if (_drawingContainerShip == null)
        {
            return;
        }

        Bitmap bmp = new(pictureBoxContainerShip.Width, pictureBoxContainerShip.Height);
        Graphics gr = Graphics.FromImage(bmp);
        _drawingContainerShip.DrawShip(gr);
        pictureBoxContainerShip.Image = bmp;
    }
}
