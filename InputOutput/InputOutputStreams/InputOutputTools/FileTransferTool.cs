namespace InputOutputTools
{
    using System;
    using System.IO;
    using System.Threading;

    public class FileTransferTool
    {
        private const int BufferSize = 8 * 1024; // 8 KB

        private string sourceFilePath;
        private string destinationFilePath;
        private ManualResetEvent manualResetEvent;
        private CancellationTokenSource cancellationTokenSource;

        public FileTransferTool(string srcFilePath, string destFilePath)
        {
            this.sourceFilePath = srcFilePath;
            this.destinationFilePath = destFilePath;
            this.manualResetEvent = new ManualResetEvent(true);
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            // Open the source file for reading
            FileStream srcFileStream = File.OpenRead(sourceFilePath);

            FileStream destFileStream;
            if (File.Exists(destinationFilePath))
            {
                destFileStream = File.OpenWrite(destinationFilePath);
                // destFileStream.Seek(0, SeekOrigin.End);
            }
            else
            {
                destFileStream = File.Create(destinationFilePath);
            }

            byte[] buffer = new byte[BufferSize];
            long totalBytesRead = 0;
            long srcFileSize = srcFileStream.Length;

            while (totalBytesRead < srcFileSize && !cancellationTokenSource.IsCancellationRequested)
            {
                manualResetEvent.WaitOne();

                int bytesRead = srcFileStream.Read(buffer, 0, buffer.Length);
                destFileStream.Write(buffer, 0, bytesRead);

                totalBytesRead += bytesRead;

                Thread.Sleep(5);

                // DisplayPercentageProgress(totalBytesRead, srcFileSize);
                // DisplayProgressBar(totalBytesRead, srcFileSize);
            }

            if (cancellationTokenSource.IsCancellationRequested)
            {
                Console.WriteLine("File transfer was cancelled");
            }
            else
            {
                Console.WriteLine("File transfer completed");
            }

            Console.WriteLine();

            srcFileStream.Close();
            destFileStream.Dispose();
        }

        public void Cancel()
        {
            cancellationTokenSource.Cancel();
        }

        public void Pause()
        {
            manualResetEvent.Reset();
        }

        public void Resume()
        {
            manualResetEvent.Set();
        }



        // The \r character is a carriage return character, also known as a "return to beginning of line" character.
        // When the console encounters a \r character, it moves the cursor back to the beginning of the current line,
        // effectively "erasing" everything that was previously displayed on the line.
        private void DisplayPercentageProgress(long totalBytesRead, long srcFileSize)
        {
            // Calculate and display progress
            int progress = (int)((double)totalBytesRead / srcFileSize * 100);
            Console.Write("Progress: {0}%\r", progress);
        }

        private void DisplayProgressBar(long totalBytesRead, long srcFileSize)
        {
            int progressBarWidth = Console.WindowWidth - 20;

            // Calculate progress percentage and progress bar width
            double progressPercentage = (double)totalBytesRead / srcFileSize;
            int progressWidth = (int)Math.Round(progressPercentage * progressBarWidth);

            // Display progress bar
            Console.Write("[{0}{1}] {2}%\r",
                new string('#', progressWidth),
                new string('-', progressBarWidth - progressWidth),
                (int)Math.Round(progressPercentage * 100));
        }
    }
}
