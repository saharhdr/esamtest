using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Component
{
    public class IntTable : DataTable
    {

        public IntTable()
        {
            this.Columns.Add("ID");
        }
        public void Add(int id)
        {
            this.Rows.Add(id);
        }

        public static IntTable Convert(List<int> uselist)
        {
            IntTable result = new IntTable();

            foreach (int item in uselist)
            {
                result.Add(item);
            }
            return result;
        }

    }
    public class DropDownTable : DataTable
    {
        public DropDownTable()
        {
            this.Columns.Add("ID");
            this.Columns.Add("Value");
        }
        public void Add(int id,string value)
        {
            object _val = null;
            if (!string.IsNullOrEmpty(value))
                _val = value;
            this.Rows.Add(id,value);
        }
    }
    public class DubleIntTable:DataTable
    {
        public DubleIntTable()
        {
            this.Columns.Add("ID1");
            this.Columns.Add("ID2");
        }
        public void Add(int id1, int id2)
        {
            object _id1 = null;
            if (id1 != 0)
                _id1 = id1;
           
            this.Rows.Add(_id1, id2);
        }
    }
}