using CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CustomerApp.Formatters
{
    public class XmlExtractor
    {
        public enum DocType{
            Expense,
            Reservation
        }
        /// <summary>
        /// This method extracts the DocType to facilitate processing
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>DocType</returns>
        public DocType DetectType(string input)
        {
            if (input.Contains(@"<Expense>"))
                return DocType.Expense;
            else
                return DocType.Reservation;

        }
        public string CleanText(string input)
        {
            return "";
        }

        public  string ParseText(string input)
        {
            int EndIndex = -1; 

            StringBuilder builder = new StringBuilder();

            int RightCount = 0;
            int LeftCount = 0;
            int counter = 0;
            //Loop through chars
            foreach (char item in input)
            {

                if (item == '<' && builder.ToString() == "")
                {
                    builder.Append(item);

                }
                if (item == '<')
                {
                    LeftCount++;
                }
                if (item == '>')
                {
                    EndIndex = counter;
                    RightCount++;
                }
                if (builder.ToString() != "")//the xml section has started
                {
                    builder.Append(item);
                }
                counter++;
            }
            if (LeftCount != RightCount)
            {
                throw new Exception("XML Document is malformed!");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Takes a IXmldocs Type and an input string and returns the relevant poco object
        /// </summary>
        /// <typeparam name="IXmldocs">IXmldocs</typeparam>
        /// <param name="input">string</param>
        /// <returns>object</returns>
        public object GetXMLDocument<IXmldocs>(string input)
        {
            XmlExtractor.DocType doctype = DetectType(input);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(input);
            XmlSerializer serializer = new XmlSerializer(typeof(IXmldocs));
            StringReader reader = new StringReader(input);
            Object ex = (IXmldocs)serializer.Deserialize(reader);

            if (DoesCostCentreExist(ex) == false)
            {
                if (doctype == DocType.Expense)
                {
                    ((Expense)(ex)).Cost_Centre = @"UNKNOWN";
                }
            }
            ValidateTotal(ex);

            return ex;
        }

        private bool DoesCostCentreExist(object input)
        {
            bool result = false;
             try
            {
                Expense TotalCheck = (Expense)(input);
                string testvalue = TotalCheck.Cost_Centre.ToString();

                if (string.IsNullOrEmpty(testvalue))
                {
                    result = false;
                }
                else result = true;
            }
            catch //Do nothing just to break on the cast to expense if its a reservation
            {
               
            }
            return result;
        }

        private void ValidateTotal(object input)
        {
            try
            {
                Expense TotalCheck = (Expense)(input);
                string testvalue = TotalCheck.Total.ToString();

                if (string.IsNullOrEmpty(testvalue))
                {
                    throw new Exception("Total Value not supplied!");
                }
            }
            catch //Do nothing just to break on the cast to expense if its a reservation
            {

            }
        }

    }
}
