using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC_Data_Migr;
using CC_Data_Migr.Models;
using CC_Data_Migr.Models.ccinput;
using CC_Data_Migr.Models.ccoutput;

namespace CC_Data_Migr
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // check any optional arguments - if present, it must be integer and match a valid idClient on ccinput
            //
            int startClient = determineStartClient(args);
            if (startClient > 0)
            {
                //
                // Does this id exist?
                //
                ccinput inputDB = new ccinput();  // open the input database
                Boolean recordPresent = inputDB.C1client.Where(a => a.idClient == startClient).Any();
                if (!recordPresent)
                {
                    Console.WriteLine("Sorry, client with a number " + startClient + " does not exist from which to start the extract");
                }
                else
                {
                    // output the single record
                    C1client record = inputDB.C1client.Where(a => a.idClient == startClient).First();
                    ccoutput outputDB = new ccoutput();
                    openOutput(outputDB);
                    processClient(record,outputDB);
                }
            }
            else
            {
                // Output the whole dataset
            }

            void openOutput(ccoutput o)
            {
                var table = o.clients.ToList();      // select all entried in the clients table
                var clear = o.clients.RemoveRange(table);
                o.SaveChangesAsync();
            }
            void processClient(C1client c, ccoutput o)
            {
                // take existing record r, format it into the output, plus read/format children on this record
                formatClient(o);

                void formatClient(ccoutput oo)
                {
                    // field by field format of output record from given input record. Then write it.
                    oo.clients.Add(new client
                    {
                        addressline1 = c.AddressLine1.ToString(),
                        addressline2 = c.AddressLine2.ToString(),


                    }
                        );
                }
            }
            int determineStartClient(string[] array)
            {
                int Client = 0;
                if (array.Length >= 1)
                {
                    try
                    {
                        Client = int.Parse(array[0]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Whoops!, the only allowed input is an integer representing the id of the single client for whom to extract data");

                    }

                }
                return Client;
            }
        }
    }
}
