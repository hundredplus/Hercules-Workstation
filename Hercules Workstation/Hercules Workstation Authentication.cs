using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hercules_Workstation
{
    public partial class Hercules_Workstation_Authentication : Form
    {
        public Hercules_Workstation_Authentication()
        {
            InitializeComponent();
        }

        String stationNo = "";
        String projectCode = "";
        public bool loginSuccessful = false;

        private void Hercules_Workstation_Authentication_Load(object sender, EventArgs e)
        {
            //Clear all
            stationTxt.Clear();
            projectBox.Items.Clear();
            processTxt.Clear();
            usernameTxt.Clear();
            passwordTxt.Clear();

            //Load station config from file
            string[] lines = System.IO.File.ReadAllLines(@".\station.txt");
            stationNo = lines[0].Trim();
            stationTxt.Text = stationNo;
            
            DBConnection dbConn = new DBConnection();
            DataTable table = dbConn.getAllProjectByStatus(2); //2=ONGOING

            Console.WriteLine("#ongoing project=" + table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                projectBox.Items.Add(row["code"].ToString());
            }
        }

        private void projectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            processTxt.Clear();
            projectCode = (String)projectBox.SelectedItem;


            Console.WriteLine(stationNo + "--" + projectCode);

            DBConnection dbConn = new DBConnection();
            DataTable table = dbConn.getProcessByProjectCodeAndStation(projectCode, stationNo);

            if (table.Rows.Count > 0)
            {
                processTxt.Text = table.Rows[0]["name"].ToString();
            }
       
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginSuccessful = true;
            this.Close();

        }
    }
}
