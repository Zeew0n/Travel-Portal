using System;

//Author:arjuns.sapkota@gmail.com
namespace ATLTravelPortal.PdfConverter
{
    public class ProcessOutputEventArgs : EventArgs
    {
        public ProcessOutputEventArgs(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
    }
}