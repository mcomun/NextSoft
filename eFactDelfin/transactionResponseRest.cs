using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eFactDelfin
{
    public class transactionResponseRest
    {

        public byte[] cdrFile { get; set; }
        public string digestValue { get; set; }
        public string identifier { get; set; }
        public string outString { get; set; }
        public byte[] pdfFile { get; set; }
        public int responseCode { get; set; }
        public sunatError sunatError { get; set; }
        public byte[] xmlSigned { get; set; }
    }
}
