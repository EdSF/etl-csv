using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DelimitedFileParsing.Models;
using DelimitedFileParsing.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DelimitedFileParsing
{
    class Program
    {

        private static readonly string FileName = Path.Combine(Environment.CurrentDirectory, "input.csv");

        static void Main()
        {
            ProcessData();
        }

        private static void ProcessData()
        {
            if (!File.Exists(FileName))
                throw new FileNotFoundException($"{FileName} does not exist");


            var fs = File.OpenRead(FileName);
            var data = Parser.ParseFile(fs, ",", true);
            bool stop =false;
            var file = new BatchFile();
            var order = new Order();
            var orders = new List<Order>();
            var orderItems = new List<OrderItem>();

            foreach (string[] strArr in data)
            {
                switch (strArr[0])
                {
                    case "F":
                        file.MapFields(strArr);
                        break;
                    case "H":
                        order.MapFields(strArr);
                        break;
                    case "B":
                        var billing = new Billinginfo();
                        billing.MapFields(strArr);
                        order.BillingInfo = billing;
                        break;
                    case "S":
                        var shipping = new Shippinginfo();
                        shipping.MapFields(strArr);
                        order.ShippingInfo = shipping;
                        break;
                    case "M":
                        var msg = new Message();
                        msg.MapFields(strArr);
                        order.OrderMessage = msg;
                        break;
                    case "L":
                        var li = new OrderItem();
                        li.MapFields(strArr);
                        orderItems.Add(li);
                        break;
                    case "T":
                        var trnx = new TransactionData();
                        trnx.MapFields(strArr);
                        order.TransactionData = trnx;
                        order.OrderLineItems = orderItems;
                        orders.Add(order);
                        file.Orders = orders;
                        
                        order = new Order();
                        orderItems = new List<OrderItem>();
                        break;
                    default:
                        var eof = new Eof();
                        eof.MapFields(strArr);
                        file.Eof = eof;
                        stop = true;
                        break;
                }

                if(stop)
                    break;
            }

            fs.Dispose();
            
            var json = JsonConvert.SerializeObject(file, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Include,
                DateFormatString = "MM/dd/yyyy"
            });

            Console.WriteLine(json);
            var saveFile = Path.Combine(Environment.CurrentDirectory, "csv-to-json.json");
            File.WriteAllText(saveFile, json);
            //Console.ReadLine();
            Process.Start(saveFile);

        }
    }
}
