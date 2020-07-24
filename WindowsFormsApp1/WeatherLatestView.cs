using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WeatherLatestView : Form
    {
        private readonly string ConnectionString = @"D:\SQLite\20200525_Udemy\DDD.db;Version=3;";
        public WeatherLatestView()
        {
            InitializeComponent();
        }

        private void LatestButton_Click(object sender, EventArgs e)
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
            using(var connection = new SQLiteConnection(ConnectionString))
            using(var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", this.AreaIdTextBox.Text);

            }
        }
    }
}
