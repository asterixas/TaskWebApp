using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TaskWebApp.Models;

namespace TaskWebApp.ModelBinderHelper
{
    public class CSVFileEngineParser: FileEngineParser
    {
        public override List<TaxViewModel> ParseFile(string fileName, System.IO.Stream inputStream)
        {
            StreamReader csvreader = new StreamReader(inputStream);
            
            List<TaxViewModel> modelList = new List<TaxViewModel>();

            for (int i = 0; i < 5;i++)
            {
                csvreader.ReadLine();

            }
            try {
                while (!csvreader.EndOfStream)
                {
                    var line = csvreader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        break;
                    var values = line.Split(';');
                    var taxModel = new TaxViewModel();
                    taxModel.DocumentName = fileName;
                    if (!string.IsNullOrEmpty(values[0]))
                        taxModel.Account = values[0];
                    if (!string.IsNullOrEmpty(values[1]))
                        taxModel.Description = values[1];
                    if (!string.IsNullOrEmpty(values[2]))
                        taxModel.CurrencyCode = values[2];
                   
                    if (!string.IsNullOrEmpty(values[3]))
                       // if (decimal.TryParse(values[3], out amount))
                        {
                            taxModel.Amount = values[3];
                        }

                    modelList.Add(taxModel);
                }



                }
            catch(Exception ex)
            {


                throw new Exception(ex.Message);
            }

            finally
                {

                    csvreader.Close();


                }
            return modelList;
        }
    }
}