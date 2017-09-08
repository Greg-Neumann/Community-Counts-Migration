using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
                    // output the single client record
                    C1client record = inputDB.C1client.Where(a => a.idClient == startClient).First();
                    ccoutput outputDB = new ccoutput();
                    openOutput(outputDB);
                    outputDB.Configuration.AutoDetectChangesEnabled = false; // fields are validated in program - do not let Entity framework do it as well
                    outputDB.Configuration.ValidateOnSaveEnabled = false; // fields are validated in program - do not let Entity framework do it as well
                    processClient(record,outputDB);
                    // output any / all activities (services) for this client
                    processAttendanceandAttendance(inputDB, record, outputDB);
                    processCasework(inputDB, record, outputDB);
                    processNeeds(inputDB, record, outputDB);
                }
            }
            else
            {
                // Output the whole dataset
                ccinput inputDB = new ccinput(); // open the input database for reading of it all
                List<C1client> c1client = inputDB.C1client.Where(a=>a.idClient>1).ToList(); // idclient=1 is a system record
                ccoutput outputDB = new ccoutput();
                openOutput(outputDB);
                outputDB.Configuration.AutoDetectChangesEnabled = false; // fields are validated in program - do not let Entity framework do it as well
                outputDB.Configuration.ValidateOnSaveEnabled = false; // fields are validated in program - do not let Entity framework do it as well
                //
                // process indicator....
                //
                int counter = 0;
                Console.WriteLine("processing all clients.");
                foreach (var c in c1client)
                {
                    processClient(c, outputDB);
                    processAttendanceandAttendance(inputDB, c, outputDB);
                    processCasework(inputDB, c, outputDB);
                    processNeeds(inputDB, c, outputDB);
                    counter++;
                    if ((counter-1) % 100 ==0 )
                    { Console.Write("."); }
                }
            }
            //
            // end of main program
            //

            void processNeeds(ccinput inputDB, C1client c, ccoutput o)
            {
                C1clientneedsheader header = inputDB.C1clientneedsheader.Where(a => a.idClient == c.idClient).First();
                if ( header!=null)
                {
                    if (header.ClientNeedsNotes!=null  && header.ClientNeedsNotes!=String.Empty)       // suppress blank / non-existant notes
                        o.needsnotes.Add(new needsnote
                        {
                            date = header.ClientNeedsDate.ToString("yyyyMMdd"),
                            idclient = header.idClient.ToString("000000"),
                            idneeds = header.idClientNeeds.ToString("000000"),
                            notes = header.ClientNeedsNotes
                        });
                    //
                    // Done Header (for the notes). Now need to process the detail records.
                    //
                    List<C1clientneedsdetail> details = inputDB.C1clientneedsdetail.Where(a => a.idClientNeeds == header.idClientNeeds).ToList();
                    foreach (var items in details)

                    {
                        string needName = "";
                        if (items.hasThisNeed)
                        {
                            needName = items.C1clientneedscat.Category;
                            o.needs.Add(new need
                            {
                                idclient = header.idClient.ToString("000000"),
                                idneeds = items.idClientNeedsDetail.ToString("000000"),
                                needscategory = needName
                            });

                        }
                    };
                }
                o.SaveChanges();
            }
            void processCasework(ccinput inputDB, C1client c, ccoutput o)
            {
                
                bool hasCasework = inputDB.C1clientcaseheader.Where(a => a.idClient == c.idClient).Any();
                if (hasCasework)
                {
                    C1clientcaseheader caseid = inputDB.C1clientcaseheader.Where(a => a.idClient == c.idClient).First();
                    List<C1clientcaseservice> caseservice = inputDB.C1clientcaseservice.Where(a => a.idClientCaseHeader == caseid.idClientCaseHeader).ToList();
                    foreach (var service in caseservice)
                    {
                        List<C1clientcaseservicedetail> casedetail = inputDB.C1clientcaseservicedetail.Where(a => a.idClientCaseDetail == service.idClientCaseDetail).ToList();
                        foreach (var caseworkdetail in casedetail)
                        {
                            string emailName = "";
                            if  (caseworkdetail.user != null)
                            { emailName = caseworkdetail.user.Email; }
                            o.caseworks.Add(new casework
                            {
                                activity=service.C1servicetypes.ServiceType,
                                date=caseworkdetail.CaseServiceDate.ToString("s"),
                                idcasework=caseworkdetail.idClientCaseServiceDetail.ToString("000000"),
                                notes=caseworkdetail.CaseServiceNotes,
                                staff=emailName,
                                time=caseworkdetail.CaseServiceTime.ToString("hhmm")
                            }
                            );
                        }
                    }
                    
                }
                o.SaveChanges();
            };
            void processAttendanceandAttendance(ccinput inputDB, C1client c, ccoutput o)
            {
                List <C1service> activities = inputDB.C1service.Where(a => a.idClient == c.idClient).ToList();
                foreach (var item in activities)
                {
                    string unenrolleddate="";
                    if (item.EndedDate != null)
                    { unenrolleddate = item.EndedDate.ToString(); }
                    //
                    o.activities.Add(new activity
                    {
                        activityname = item.C1servicetypes.ServiceType,
                        createdate = item.CreateDate.ToString("s"),
                        enrolleddate = item.StartedDate.ToString("s"),
                        idactivity = item.idService.ToString("000000"),
                        idclient = item.idClient.ToString("000000"),
                        UnenrolledDate= unenrolleddate
                });
                    //
                    // process all attendances for this activity and client
                    //
                    // if activity was unenrolled, then only pull off, this time round, the attendances upto and including the unenrolled date.
                    // If they subsequently re-enroll, then we will pull of subsequent attendances for the subsequent activity re-enrollment
                    // This precaustion is needed to avoid the same full set of attendances being pulled off for each activity and creating
                    // articifical duplicates in the attendance file
                    //
                    List<C1attendance> attendances = new List<C1attendance>();
                    if (item.EndedDate == null) // no re-enrollment - list all attendances
                    {
                        attendances = inputDB.C1attendance
                           .Where(a => a.idServiceType == item.idServiceType)
                           .Where(a => a.idClient == item.idClient)
                           .Where(a => a.SessionDate >= item.StartedDate)
                           .ToList();

                    }
                    else                                   // re-enrollment may exist - only list attendances up to date of unenrollment
                    {
                        attendances = inputDB.C1attendance
                           .Where(a => a.idServiceType == item.idServiceType)
                           .Where(a => a.idClient == item.idClient)
                           .Where(a => a.SessionDate < item.EndedDate)
                           .Where(a=>a.SessionDate >= item.StartedDate)
                           .ToList();
                    }
                        foreach (var attendance in attendances)
                    {
                        o.attendances.Add(new attendance
                        {
                            activity = attendance.C1servicetypes.ServiceType,
                            attendedcount = attendance.AttendedCount.ToString("00"),
                            attendedtime = attendance.AttendedTime.ToString("hhmmss"),
                            idattendance = attendance.idAttendance.ToString("000000"),
                            idclient = attendance.idClient.ToString("000000"),
                            resource = attendance.C1resources.ResourceName,
                            sessiondate=attendance.SessionDate.ToString("yyyyMMdd"),
                            sessiontime=attendance.SessionTime.ToString("hhmmss"),
                            signintime=attendance.SignInTime.ToString("hhmmss"),
                            signouttime=attendance.SignOutTime.ToString("hhmmss")
                        });

                    }
                }
                o.SaveChanges();  
            }
            void openOutput(ccoutput o)
            {
                var table = o.clients.ToList();      // select all entries in the clients table
                var clear = o.clients.RemoveRange(table);
                o.SaveChanges();
                var activities = o.activities.ToList();
                var clearActivities = o.activities.RemoveRange(activities);
                o.SaveChanges();
                var attendances = o.attendances.ToList();
                var clearAttendences = o.attendances.RemoveRange(attendances);
                o.SaveChanges();
                var casework = o.caseworks.ToList();
                var clearCasework = o.caseworks.RemoveRange(casework);
                o.SaveChanges();
                var needs = o.needs.ToList();
                var clearNeeds = o.needs.RemoveRange(needs);
                o.SaveChanges();
                var needNotes = o.needsnotes.ToList();
                var clearNeedsNotes = o.needsnotes.RemoveRange(needNotes);
                o.SaveChanges();
            }
            void processClient(C1client c, ccoutput o)
            {
                // take existing record r, format it into the output, plus read/format children on this record
                formatClient(o);

                void formatClient(ccoutput oo)
                {
                    // field by field format of output record from given input record. Then write it.
                    // Deal with nullable fields first
                    string addressLine2="", houseNumber="", county="", phone="",email ="", ethnicity_other="", occupation_other="", hear_other="",tennant_status="",idclientPrev="";
                    if (c.AddressLine2!=null)
                    { addressLine2 = simple_unscramble(c.AddressLine2); }
                    
                    if (c.idCounty!=null)
                    { county = c.countylist.County; }
                    
                    if(c.Phone!=null)
                    { phone = simple_unscramble(c.Phone); }

                    if(c.Email!=null)
                    { email = simple_unscramble(c.Email); }

                    if(c.Ethnicity_Other!=null)
                    { ethnicity_other = c.Ethnicity_Other; }

                    if(c.Occupation_Other!=null)
                    { occupation_other = c.Occupation_Other; }

                    if(c.HearOther!=null)
                    { hear_other = c.HearOther; }

                    if(c.idTenantStatus!=null)
                    { tennant_status = c.refdata10.RefCodeDesc; }
                    
                    if(c.HouseNumber!=null)
                    { houseNumber = simple_unscramble(c.HouseNumber); }

                    if(c.idClientPrev!=null)
                    { idclientPrev = c.idClientPrev.Value.ToString("00000"); }    // nullable types must be turned into it's value before formatting!

                    //
                    //
                    oo.clients.Add(new client
                    {
                        addressline1 = simple_unscramble(c.AddressLine1.ToString()),
                 
                        addressline2 = addressLine2,
                        agerange = c.refdata.RefCodeDesc,
                        armedservicescurrently = c.ArmedServCur.ToString(),
                        armedservicesprev = c.ArmedSerPre.ToString(),
                        benefits = c.refdata7.RefCodeDesc,
                        changeddatetime=c.ChangedDateTime.ToString("s"),
                        city = c.citylist.City,
                        county=county,
                        createddatetime=c.CreatedDateTime.ToString("s"),
                        disability=c.refdata6.RefCodeDesc,
                        email=email,
                        ethnicity=c.refdata4.RefCodeDesc,
                        ethnicity_other=ethnicity_other,
                        firstlanguage=c.refdata8.RefCodeDesc,
                        firstlanguageother=c.refdata8.RefCodeDesc,
                        firstname=simple_unscramble(c.FirstName),
                        gender=c.refdata3.RefCodeDesc,
                        hearofservices=c.refdata5.RefCodeDesc,
                        housenumber=houseNumber,
                        hearofservices_other=hear_other,
                        housingstatus=c.refdata9.RefCodeDesc,
                        idclient=c.idClient.ToString("000000"),
                        idclientprev=idclientPrev,
                        lastname=simple_unscramble(c.LastName),
                        occupation=c.refdata1.RefCodeDesc,
                        occupation_other=occupation_other,
                        phone=phone,
                        postcode=c.postcode.PostCode1,
                        regyear=c.regyear.RegYear1,
                        signedbyclient=c.ConfirmSigned.ToString(),
                        tenantstatus=tennant_status,
                        travelmethod=c.refdata2.RefCodeDesc
                    }
                    
                        );
                    oo.SaveChanges();

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
            string simple_scramble(string input)
            //
            // Community Counts scramble algorithmn - it's just simple letter substitution
            //
            {
                char[] forwards_table = new char[] {
                (char)64,(char)89,(char)76,(char)41,(char)122,(char)35,(char)119,(char)32,(char)51,(char)67,(char)101,(char)94,(char)59,(char)37,(char)53,
                (char)126,(char)33,(char)105,(char)57,(char)81,(char)79,(char)38,(char)83,(char)113,(char)46,(char)97,(char)110,(char)124,(char)43,(char)86,
                (char)62,(char)34,(char)73,(char)49,(char)123,(char)108,(char)92,(char)47,(char)116,(char)120,(char)36,(char)103,(char)82,(char)42,(char)56,
                (char)74,(char)115,(char)48,(char)87,(char)75,(char)39,(char)117,(char)71,(char)50,(char)125,(char)40,(char)72,(char)80,(char)121,(char)44,
                (char)77,(char)61,(char)104,(char)96,(char)90,(char)45,(char)69,(char)93,(char)60,(char)99,(char)112,(char)118,(char)98,(char)55,(char)95,
                (char)100,(char)106,(char)63,(char)111,(char)66,(char)65,(char)70,(char)85,(char)78,(char)52,(char)102,(char)109,(char)58,(char)114,(char)68,
                (char)54,(char)88,(char)91,(char)107,(char)84};
                int l = input.Length - 1;
                StringBuilder i_String = new StringBuilder(input);
                StringBuilder o = new StringBuilder();
                for (int c = l; c >= 0; c--)
                {
                    int i = (int)i_String[c] - 32; // cast ordinal (ASCII) value and adjust for array index lookup such that ascii 32 (space) is first element of array   
                    if ((i < 0) || (i > 94))
                    {
                        var omsg = String.Format("Data scrambling illegal index for ASCII value {0} (DEC) on input '{1}'", i, input);
                        throw new InvalidConstraintException(omsg);
                    }
                    o = o.Append(forwards_table[i]);
                }
                return o.ToString();
            }
              string simple_unscramble(string input)
                //
                // Community Counts unscramble algorithmn - it's just simple letter substitution
                //
            {
                char[] reverse_table = new char[] {
                (char)39,(char)48,(char)63,(char)37,(char)72,(char)45,(char)53,(char)82,(char)87,(char)35,(char)75,(char)60,(char)91,(char)97,(char)56,
                (char)69,(char)79,(char)65,(char)85,(char)40,(char)116,(char)46,(char)122,(char)105,(char)76,(char)50,(char)119,(char)44,(char)100,(char)93,
                (char)62,(char)109,(char)32,(char)112,(char)111,(char)41,(char)121,(char)98,(char)113,(char)84,(char)88,(char)64,(char)77,(char)81,(char)34,
                (char)92,(char)115,(char)52,(char)89,(char)51,(char)74,(char)54,(char)126,(char)114,(char)61,(char)80,(char)123,(char)33,(char)96,(char)124,
                (char)68,(char)99,(char)43,(char)106,(char)95,(char)57,(char)104,(char)101,(char)107,(char)42,(char)117,(char)73,(char)94,(char)49,(char)108,
                (char)125,(char)67,(char)118,(char)58,(char)110,(char)102,(char)55,(char)120,(char)78,(char)70,(char)83,(char)103,(char)38,(char)71,(char)90,
                (char)36,(char)66,(char)59,(char)86,(char)47};
                int l = input.Length - 1;
                StringBuilder i_String = new StringBuilder(input);
                StringBuilder o = new StringBuilder();
                for (int c = l; c >= 0; c--)
                {
                    int i = (int)i_String[c] - 32; // cast ordinal (ASCII) value and adjust for array index lookup such that ascii 32 (space) is first element of array   
                    if ((i < 0) || (i > 94))
                    {
                        var omsg = String.Format("Data Unscrambling illegal index for ASCII value {0} (DEC) on input '{1}'", i, input);
                        throw new InvalidConstraintException(omsg);
                    }
                    o = o.Append(reverse_table[i]);
                }
                return o.ToString();
            }
            
        }
    }
}
