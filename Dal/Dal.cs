﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SQLite;


namespace Dal
{
    public class AcessaDados
    {
        public string connString = @"";

        public SQLiteConnection RetornaConexao(string conString)
        {
            SQLiteConnection conn;
            try
            {
                using (conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                }
            }
            catch(SQLiteException ex)
            {
               throw  new SQLiteException(ex.Message);
            }

            return conn;
        }
    }
}
