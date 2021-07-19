using System;

namespace SlideLama
{
    [Serializable]
    public class Cell
    {
        private int _value;
        private int _positionColumn;
        private int _positionRow;
        public Cell(int column,int row,int value)
        {
            this._value = value;
            this._positionColumn = column;
            this._positionRow = row;
        }

        public int Get_value()
        {
            return _value;
        }

        public void Set_value(int value)
        {
            _value = value;
        }

        public int Get_positionColumn()
        {
            return _positionColumn;
        }

        public int Get_positionRow()
        {
            return _positionRow;
        }
    }
}