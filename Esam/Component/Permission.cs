using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Component;
using System.Data.SqlClient;

namespace Component
{
    public class Permission
    {
        private Dictionary<int, bool> continer;

        public Permission()
        {
            continer = new Dictionary<int, bool>();
        }
        public bool this[int index]
        {
            set { this.Add(index, value); }
            get
            {
                if (!this.continer.ContainsKey(index))
                    return false;
                return continer[index];
            }
        }
   
        private void Add(int index, bool value)
        {
            if (this.continer.ContainsKey(index))
                this.continer[index] = value;
            else
                this.continer.Add(index, value);
        }
      
        public bool Remove(int index)
        {
            if (!this.continer.ContainsKey(index))
                return false;
            return continer.Remove(index);
        }
        public void Update(DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                this.continer[Convert.ToInt32(item["WorkID"])] = true;
            }
        }
       
    }

    public class PermissionName
    {
        public static int SendStatement
        {
            get { return 1; }
        }
       
    }
}