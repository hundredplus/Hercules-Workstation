using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hercules_Workstation
{
    public partial class HerculesWorkstation : Form
    {
        String prodCode = null;
        bool hasJob = false;
        int myLocation = 100;
        bool cancelRequest = false;

        public HerculesWorkstation()
        {
            InitializeComponent();
        }


        private void HerculesWorkstation_Load(object sender, EventArgs e)
        {
            requestBtn.Enabled = true;
            statusLbl.Text = "Click REQUEST for a new PBU";
        }
                   

        private void requestBtn_Click(object sender, EventArgs e)
        {
            requestBtn.Enabled = false;
            cancelBtn.Enabled = true;
            statusLbl.Text = "Wait for a new PBU...";

            Thread monitorThread = new Thread(monitorChange);
            monitorThread.IsBackground = true;
            monitorThread.Start();                

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cancelRequest = true;
            cancelBtn.Enabled = false;
            requestBtn.Enabled = true;
            statusLbl.Text = "Click REQUEST for a new PBU";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            requestBtn.Enabled = false;
            startBtn.Enabled = false;
            finishBtn.Enabled = true;

            statusLbl.Text = "Started working on " + prodCode + " at " + DateTime.Now.ToString();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection dbConn = new DBConnection();
                dbConn.updateProduction(prodCode, 9); //9=INSPECT_REQ

                finishBtn.Enabled = false;
                requestBtn.Enabled = true;
                hasJob = false;
                statusLbl.Text = "Wait for inspecting or AGV to move. Click REQUEST for a new PBU.";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        
        private void monitorChange()
        {
            while (!hasJob && !cancelRequest)
            {
                //Keep looking for job in view station_work_view
                DBConnection dbConn = new DBConnection();
                DataTable table = dbConn.getWorkstationView(myLocation);

                if (table.Rows.Count > 0)
                {
                    prodCode = table.Rows[0]["production_code"].ToString();
                    MessageBox.Show("A new PBU has arrived: " + prodCode);

                    cancelBtn.Invoke((Action)delegate
                    {
                        cancelBtn.Enabled = false;
                    });

                    startBtn.Invoke((Action)delegate
                    {
                        startBtn.Enabled = true;
                    });

                    hasJob = true;
                    statusLbl.Invoke((Action)delegate
                    {
                        statusLbl.Text = "Click START to work on PBU " + prodCode;
                    });

                }

                Thread.Sleep(5000);
            }
        }

        
    }
}
