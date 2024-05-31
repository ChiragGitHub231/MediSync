using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCRS_Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceHost PatientServiceHost = new ServiceHost(typeof(HCRS_Service.PatientService));
            ServiceHost DoctorServiceHost = new ServiceHost(typeof(HCRS_Service.DoctorService));
            ServiceHost AppointmentServiceHost = new ServiceHost(typeof(HCRS_Service.AppointmentService));

            PatientServiceHost.Open();
            DoctorServiceHost.Open();
            AppointmentServiceHost.Open();

            label1.Text = "Server Running...";
        }
    }
}
