﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Common;

namespace WindowsFormsApp1.Data
{
    public static class WetherSQLite
    {
        public static DataTable GetLatest(int areaId)
        {
            string sql = @"
select DataDate,
       Condition,
       Tempareture
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1"
;
            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(CommonConst.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
        }
    }
}
