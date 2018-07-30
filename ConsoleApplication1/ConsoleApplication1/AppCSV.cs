using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;



namespace CSVApp
{
    class AppCSV
    {

        DateTimeOffset DataJoin = DateTimeOffset.MaxValue;
        public string Url { get; set; }

        public class MyData
        {
            public string user_id { get; set; }
            public DateTimeOffset date_joined { get; set; }
            public double spend { get; set; } // (in dollars)
            public string milliseconds_played { get; set; } // (in dollars)
            public string device_height { get; set; } //pixels
            public string device_width { get; set; } //pixels
        }
        public class MyMetric
        {
            public string user_id { get; set; } // (in dollars)
            public int UserCount { get; set; }
            public int ResolCount { get; set; }
            public double spendDollar { get; set; } // (in dollars)
            public DateTimeOffset DateJoin { get; set; } // (in dollars)
            public List<String> GroupError { get; set; }

        }
        public void showProcessing(String instructions)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           Processing         ");
            Console.WriteLine("======================================");
            Console.WriteLine(instructions);
        }
        public void showUsage(String instructions)
        {
            Console.WriteLine("(instructions)");
            Console.WriteLine("======================================");
            Console.WriteLine("           Usage instructions         ");
            Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.WriteLine("Enter the URL for the GZip file containing");
            Console.WriteLine("user data ");
            Console.WriteLine("");
            Console.WriteLine("======================================");
            Console.WriteLine("                Example               ");
            Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.WriteLine("ConsoleAplication1.exe \"https://s3.amazonaws.com/fabiano-tests/swrve/small.csv.gz\"");
            Console.WriteLine("");
        }
        public void showError(String errorMessage)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("               ERROR                  ");
            Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.WriteLine(errorMessage);
            Console.WriteLine("");
        }

        public void ShowPercentProgress(string message, long currElementIndex, long totalElementCount)
        {

            if (currElementIndex < 0 || currElementIndex >= totalElementCount - 1)
            {
                throw new InvalidOperationException("currElement out of range");
            }

            long percent = (100 * (currElementIndex + 1)) / totalElementCount;
            Console.Write("\r{0}{1}% complete", message, percent);
            if (currElementIndex == totalElementCount - 1)
            {
                Console.WriteLine(Environment.NewLine);
            }

        }

        public void ShowProgress(string message, long currElementIndex, long totalElementCount)
        {

            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            Console.Write("\r{0}  {1}  % complete", currElementIndex, totalElementCount);
        }



        public void showMetricsConsole(ref List<AppCSV.MyData> lstdata, ref List<AppCSV.MyMetric> lstMetric)
        {

            foreach (MyMetric dados in lstMetric)
            {
                Console.WriteLine("");
                Console.WriteLine("======================================");
                Console.WriteLine("          Metrics (detailed)          ");
                Console.WriteLine("======================================");
                Console.WriteLine("           Total user count: " + dados.UserCount.ToString());
                Console.WriteLine("          Users on 640w960h: " + dados.ResolCount.ToString());
                Console.WriteLine("               Global spend: " + dados.spendDollar.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                Console.WriteLine("Id of first user who joined: " + dados.user_id.ToString());
                Console.WriteLine("");
                Console.WriteLine("");

                foreach (string Error in dados.GroupError)
                {
                    Console.WriteLine("");
                    Console.WriteLine("======================================");
                    Console.WriteLine("          Error (wrong data)          ");
                    Console.WriteLine("======================================");
                    Console.WriteLine("" + Error);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            Console.ReadLine();


        }
        //RCF_4180
        public string ParserCSV(ref string readUz, ref MyData myData, ref MyMetric myMetric, ref Regex CSVParser)
        {
            string retorno;

            try
            {
                retorno = "";

                MatchCollection CSVRecords = CSVParser.Matches(readUz);


                DateTimeOffset parsedDate;

                Double parseDouble;

                for (Int32 recordIndex = 0; recordIndex < CSVRecords.Count; recordIndex++)
                {
                    Match Record = CSVRecords[recordIndex];
                    for (Int32 valueIndex = 0; valueIndex < Record.Groups["Value"].Captures.Count; valueIndex++)
                    {
                        Capture c = Record.Groups["Value"].Captures[valueIndex];

                        if (c.Value != "")
                        {

                            if ((("V" + (valueIndex + 1)) == "V1"))
                            {
                                myData.user_id = (c.Value).ToString();
                            }
                            else if ((("V" + (valueIndex + 1)) == "V2"))
                            {

                                //if (DateTimeOffset.TryParseExact(c.Value.Trim(), "yyyy-MM-dd'T'HH:mm:ss.SSSXXX", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                                if (DateTimeOffset.TryParse(c.Value.Trim(), out parsedDate)  == true)
                                {
                                    if (DateTimeOffset.Parse(c.Value).CompareTo(DataJoin) < 0)
                                    {
                                        DataJoin = DateTimeOffset.Parse((c.Value).ToString());
                                        myData.date_joined = DateTimeOffset.Parse((c.Value).ToString());
                                        myMetric.user_id = myData.user_id;
                                    }
                                }
                                //else
                                //{
                                //    myMetric.user_id = myData.user_id;
                                //}
                            }
                            else if ((("V" + (valueIndex + 1)) == "V3"))
                            {
                                if (Double.TryParse(c.Value, out parseDouble))
                                {
                                    myData.spend = Double.Parse((c.Value).ToString());
                                    myMetric.spendDollar += myData.spend;
                                }
                            }
                            else if ((("V" + (valueIndex + 1)) == "V4"))
                            {
                                if (Double.TryParse(c.Value, out parseDouble))
                                {
                                    myData.milliseconds_played = (c.Value).ToString();
                                }

                            }
                            else if ((("V" + (valueIndex + 1)) == "V5"))
                            {
                                myData.device_height = (c.Value).ToString();
                            }
                            else if ((("V" + (valueIndex + 1)) == "V6"))
                            {
                                myData.device_width = (c.Value).ToString();
                            }

                            //contadores
                            if (myData.device_width == "640" && myData.device_height == "960")
                            {
                                myMetric.ResolCount += 1;
                            }
                        }
                    }

                    //contador
                    myMetric.UserCount += 1;

                    foreach (Capture OpenValue in Record.Groups["OpenValue"].Captures)
                    {
                        myMetric.GroupError.Add("ERROR - Open ended quoted value: " + OpenValue.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                retorno = ex.Message.ToString();
            }

            return retorno;
        }
        public string GetProcessStream(ref string csv, string uri, ref List<AppCSV.MyData> lstdata, ref List<AppCSV.MyMetric> lstMetric)
        {
            string retorno = "";
            string line = "";
            string resultParse = "";

            long Content = 0;
            long LineLength = 0;

            //int ij = 0;
            //int i = 0;

            try
            {

                Regex CSVParser = new Regex(
            @"(?<=\r|\n|^)(?!\r|\n|$)" +
            @"(?:" +
                @"(?:" +
                    @"""(?<Value>(?:[^""]|"""")*)""|" +
                    @"(?<Value>(?!"")[^,\r\n]+)|" +
                    @"""(?<OpenValue>(?:[^""]|"""")*)(?=\r|\n|$)|" +
                    @"(?<Value>)" +
                @")" +
                @"(?:,|(?=\r|\n|$))" +
            @")+?" +
            @"(?:(?<=,)(?<Value>))?" +
            @"(?:\r\n|\r|\n|$)",
            RegexOptions.Compiled);






                var req = (HttpWebRequest)HttpWebRequest.Create(uri);

                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        Content = resp.ContentLength;

                        using (GZipStream readStreamUZ = new GZipStream(stream, CompressionMode.Decompress, true))
                        {

                            using (StreamReader readStream = new StreamReader(readStreamUZ))
                            {
                                MyMetric myMetric = new MyMetric();
                                myMetric.GroupError = new List<String>();

                                while ((line = readStream.ReadLine()) != null)
                                {
                                    LineLength += line.Length;
                                    ShowProgress("Processing...", LineLength, Content);
                                    ///
                                    MyData myData = new MyData();
                                    resultParse = ParserCSV(ref line, ref myData, ref myMetric, ref CSVParser);
                                    //lstdata.Add(myData);
                                }
                                lstMetric.Add(myMetric);
                            }

                        }
                    }

                }

            }

            catch (Exception ex)
            {
                retorno = ex.Message.ToString() + resultParse;
            }

            return retorno;
        }

        public interface ICsvParser
        {
            IEnumerable<List<string>> Parse(string csv, char separator = ';');
        }

    }




}

