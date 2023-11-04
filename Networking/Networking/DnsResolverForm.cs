using Microsoft.VisualBasic.Devices;
using System.Net;

namespace Networking
{
    public partial class DnsResolverForm : Form
    {
        public DnsResolverForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            //Dns.GetHostByName(this)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hostName = textBox1.Text;
            IPHostEntry hostEntry = Dns.GetHostByName(hostName);
            this.textBox2.Text = hostEntry.AddressList[0].ToString();
            //IPAddress.Loopback;

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}