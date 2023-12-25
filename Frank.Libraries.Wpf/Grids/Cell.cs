using System.Windows.Controls;

using Frank.Libraries.Wpf.Extensions;

namespace Frank.Libraries.Wpf.Grids;

public class Cell : Frame
{
    private CellPosition _position;

    public Cell(CellPosition position)
    {
        SetPosition(position);
    }

    public CellPosition GetPosition() => _position;

    public void SetPosition(CellPosition position)
    {
        _position = position;
        this.SetGridPosition(_position.Column, _position.Roww);
    }
}