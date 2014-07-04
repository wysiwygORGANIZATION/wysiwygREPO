using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpdesk.HelpdeskServiceRef;


namespace Helpdesk
{
    public partial class NewPlaylist : Form
    {

        List<HelpdeskMusic> hmusics;

        public NewPlaylist()
        {
            InitializeComponent();
            HelpdeskWSClient client = new HelpdeskWSClient();
            hmusics = client.MusicsRequest().ToList();
            dataGridView1.DataSource = hmusics;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<HelpdeskMusic> selectedMusics = new List<HelpdeskMusic>();
            int i=0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value!=null && (bool)row.Cells[0].Value == true)
                    selectedMusics.Add(hmusics.ElementAt(i));
                i++;
            }
            HelpdeskWSClient client = new HelpdeskWSClient();
            client.AddPlaylist(selectedMusics.ToArray());
            this.Dispose();
        }
    }
}
