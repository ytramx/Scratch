using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScratchForm
{
    public partial class ReadableJsonForm : Form
    {
        public ReadableJsonForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Some comments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(fileOpener.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = fileOpener.FileName;
                this.btnOutput_Click(null, null);
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.txtFile.Text.Trim()))
                this.txtOutput.Text = ReadAndOutput(this.txtFile.Text.Trim());
            else
                MessageBox.Show("File is not the existing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string ReadAndOutput(string file)
        {
            var obj = JsonConvert.DeserializeObject(File.ReadAllText(file));
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
