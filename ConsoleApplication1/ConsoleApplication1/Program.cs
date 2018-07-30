using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace CSVApp
{
    class Program
    {

        /**
 * Exit codes
 */
        static int EXIT_CODE_OK = 0;
        static int EXIT_CODE_MISSING_URL = 10;
        static int EXIT_CODE_INVALID_URL = 11;
        static int EXIT_CODE_FETCH_ERROR = 12;
        static int EXIT_CODE_DECOMPRESSION_ERROR = 13;
        static int EXIT_CODE_UNEXPECTED_ERROR = 14;
        static int EXIT_CODE_GETSTREAM_ERROR = 15;
        static int EXIT_CODE_PARSERSTREAM_ERROR = 16;

        public static void Main (String[] args)
        {
            Program app = new Program();
            int exitCode = app.AppCSV(args);
            Environment.Exit(exitCode);
        }

        public int AppCSV(String[] args)
        {
            //Test 001
            AppCSV ClasseOperacao = new AppCSV();

           //Test 002
            if (args == null || args.Length == 0)
            {
                ClasseOperacao.showUsage("An URL for the GZip file containing user data must be provided");
                ClasseOperacao.showError(EXIT_CODE_MISSING_URL.ToString());
                Console.WriteLine("Validacao url");
                Console.ReadLine();
                //return EXIT_CODE_MISSING_URL;
            }
            //Test 003 valida url
            ClasseOperacao.Url = args[0];

            List<AppCSV.MyData> list = new List<AppCSV.MyData>();
            List<AppCSV.MyMetric> listMetric = new List<AppCSV.MyMetric>();

           //Valida URL
            string Csv = "";
            string resultGetProcess = ClasseOperacao.GetProcessStream(ref Csv, ClasseOperacao.Url, ref list, ref listMetric);
            if (resultGetProcess != "")
            {
                ClasseOperacao.showUsage(resultGetProcess);
                ClasseOperacao.showError(EXIT_CODE_GETSTREAM_ERROR.ToString());
                Console.WriteLine(resultGetProcess);
                Console.ReadLine();
                //return EXIT_CODE_GETSTREAM_ERROR;
            }
            else {
                ClasseOperacao.showMetricsConsole(ref list, ref listMetric);
            }

            ClasseOperacao.showError(EXIT_CODE_OK.ToString());
            return EXIT_CODE_OK;
        }



    }
}

