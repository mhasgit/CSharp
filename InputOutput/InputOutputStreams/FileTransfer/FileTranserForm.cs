using InputOutputTools;
using System;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class FileTranserForm : Form
    {
        private string sourceFileName;
        private string destinationFileName;
        private FileTransferTool fileTransferTool;

        public FileTranserForm()
        {
            InitializeComponent();

            this.sourceLbl.Text = string.Format("Source: {0}", sourceFileName);
            this.destLbl.Text = string.Format("Source: {0}", destinationFileName);

            this.fileTransferTool = new FileTransferTool(sourceFileName, destinationFileName);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.fileTransferTool.Start();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            this.fileTransferTool.Pause();
        }

        private void resumeBtn_Click(object sender, EventArgs e)
        {
            this.fileTransferTool.Resume();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.fileTransferTool.Cancel();
        }

        private void chooseSrcBtn_Click(object sender, EventArgs e)
        {
            this.sourceLbl.Text = GetFileName();
        }

        private void chooseDestBtn_Click(object sender, EventArgs e)
        {
            this.destLbl.Text = GetFileName();
        }

        private string GetFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
