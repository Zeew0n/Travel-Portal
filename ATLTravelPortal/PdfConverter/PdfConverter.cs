using System;
using System.Diagnostics;
using ATLTravelPortal.PdfConverter;

//Author:arjuns.sapkota@gmail.com
namespace ATLTravelPortal.PdfConverter
{
    public class PdfConverter
    {
        private readonly Process process;

        public PdfConverter(string inputfileName, string outputFilename)
        {
            //at the begining Has Error is True

            string pdfConverterExe = System.Web.HttpContext.Current.Server.MapPath("~/Lib/Wkhtmltopdf.exe");
            HasError = true;
            process = new Process
                           {
                               StartInfo = new ProcessStartInfo
                                               {
                                                   FileName = pdfConverterExe,
                                                   UseShellExecute = false,
                                                   Arguments = String.Format("--dpi 300 \"{0}\"  \"{1}\" ", inputfileName, outputFilename),
                                                   RedirectStandardOutput = true,
                                                   CreateNoWindow = true
                                               },
                               EnableRaisingEvents = true
                           };
            process.OutputDataReceived += OutputDataReceived;
            process.Exited += ProcessExited;
        }

        public bool HasError { get; private set; }
        public event EventHandler<ProcessOutputEventArgs> OutputData;

        private void ProcessExited(object sender, EventArgs e)
        {
            HasError = process.ExitCode != 0;
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            OnOutputData(e.Data);
        }

        public void Run()
        {
            process.Start();
            process.WaitForExit();
        }

        protected virtual void OnOutputData(string data)
        {
            if (OutputData != null)
            {
                OutputData(this, new ProcessOutputEventArgs(data));
            }
        }
    }
}