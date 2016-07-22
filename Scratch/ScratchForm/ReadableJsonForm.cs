using Newtonsoft.Json;
using System;
using System.IO;
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

        /// <summary>
        /// Some more comments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.txtFile.Text.Trim()))
            {
                errProvider.Clear();
                this.txtOutput.Text = ReadAndOutput(this.txtFile.Text.Trim());
            }
            else
                errProvider.SetError(this.txtFile, "File is not the existing!");
        }

        private string ReadAndOutput(string file)
        {
            var obj = JsonConvert.DeserializeObject(File.ReadAllText(file));
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
