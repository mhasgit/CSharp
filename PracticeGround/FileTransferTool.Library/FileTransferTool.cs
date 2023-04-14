using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeGround
{
    public class FileTransferTool
    {
        private const int BufferSize = 8 * 1024;

        private string sourceFilePath;
        private string destFilePath;
        private ManualResetEvent manualResetEvent;
        private CancellationTokenSource cancellationTokenSource;


        public FileTransferTool(string srcFile, string destFile)
        {
            this.sourceFilePath = srcFile;
            this.destFilePath = destFile;
            this.manualResetEvent = new ManualResetEvent(true);
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {

            FileStream srcFileStream = File.OpenRead(sourceFilePath);

            FileStream destFileStream;

            if (File.Exists(destFilePath))
            {
                destFileStream = File.OpenWrite(destFilePath);
            }
            else
            {
                destFileStream = File.Create(destFilePath);
            }

            byte[] buffer = new byte[BufferSize];
            long totalBytesRead = 0;
            long srcFileSize = srcFileStream.Length;


            while (totalBytesRead < srcFileSize  && cancellationTokenSource.IsCancellationRequested)
            {
                manualResetEvent.WaitOne();

                int bytesRead = srcFileStream.Read(buffer, 0, buffer.Length);
                destFileStream.Write(buffer, 0, bytesRead);

                totalBytesRead += bytesRead;

                Thread.Sleep(5);
            }
            DisplayPercentageProgress(totalBytesRead, srcFileSize);
            //DisplayProgressBar(totalBytesRead, srcFileSize);

            if (cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("File transfer was cancelled");
            }
            else
            {
                Console.WriteLine("File transfer was completed");
            }

            Console.WriteLine();

            srcFileStream.Close();
            destFileStream.Dispose();
        }

        private void DisplayPercentageProgress(long totalBytesRead, long srcFileSize)
        {
            int progress = (int)((double)totalBytesRead / srcFileSize * 100);
            Console.WriteLine("Progress {0}%\r", progress);
        }

        private void DisplayProgressBar(long totalBytesRead, long srcFileSize)
        {
            int progressBarWidth = Console.WindowWidth - 20;

            double progressPercentage = (double)totalBytesRead / srcFileSize;
            int progressWidth = (int)Math.Round(progressPercentage * progressBarWidth);

            Console.WriteLine("[{0}{1}] {2}%\r", new string('#', progressWidth)
                , new string('-', progressBarWidth - progressWidth)
                , (int)Math.Round(progressPercentage * 100));
        }
    }
}
