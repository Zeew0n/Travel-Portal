using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using Galileo.PnrService;
using Galileo.FareService;
using System.Text;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PNRInfoProvider
    {
        EntityModel entity = new EntityModel();

        //public Int64 SavePNRInformation(int AgentId,
        //                                    int ServiceProviderId,
        //                                    string Prefix,
        //                                    string FirstName,
        //                                    string MiddleName,
        //                                    string LastName,
        //                                    string Email,
        //                                    string ContactNumber,
        //                                    string GDSRefrenceNumber,
        //                                    int TicketStatusId,
        //                                    int CreatedBy,
        //                                    DateTime CreatedDate,
        //                                    DateTime? TTL,
        //                                    DateTime? ATLTTL
        //                                )
        //{
        //    var obj = new PNRs
        //    {
        //        AgentId = AgentId,
        //        ServiceProviderId = ServiceProviderId,
        //        Prefix = Prefix,
        //        FirstName = FirstName,
        //        MiddleName = MiddleName,
        //        LastName = LastName,
        //        EmailAddress = Email,
        //        ContactNumber = ContactNumber,
        //        GDSRefrenceNumber = GDSRefrenceNumber,
        //        TicketStatusId = TicketStatusId,
        //        CreatedBy = CreatedBy,
        //        CreatedDate = CreatedDate,
        //        TTL = TTL,
        //        ATLTTL = ATLTTL
        //    };

        //    entity.AddToPNRs(obj);
        //    entity.SaveChanges();

        //    return obj.PNRId;
        //}

        //public Int64 SavePNRSectorInformation(int platingCarrierId,
        //                                    Int64 PNRId,
        //                                    int DepartureCityId,
        //                                    DateTime DepartureDate,
        //                                    string DepartureTime,
        //                                    int DestinationCityId,
        //                                    DateTime ArriveDate,
        //                                    string ArriveTime,
        //                                    string StartTerminal,
        //                                    string EndTerminal,
        //                                    int CreatedBy,
        //                                    DateTime CreatedDate)
        //{
        //    var obj = new PNRSectors
        //    {
        //        PlatingCarrierId = platingCarrierId,
        //        PNRId = PNRId,
        //        DepartCityId = DepartureCityId,
        //        DepartDate = DepartureDate,
        //        DepartTime = TimeSpan.Parse(DepartureTime),
        //        DestinationCityId = DestinationCityId,
        //        ArriveDate = ArriveDate,
        //        ArriveTime = TimeSpan.Parse(ArriveTime),
        //        StartTerminal = StartTerminal,
        //        EndTerminal = EndTerminal,
        //        CreatedBy = CreatedBy,
        //        CreatedDate = CreatedDate
        //    };

        //    entity.AddToPNRSectors(obj);
        //    entity.SaveChanges();

        //    return obj.SectorId;
        //}

        //public void SavePNRSegmentInformation(Int64 PNRId,
        //                                        Int64 SectorId,
        //                                        int AirlineId,
        //                                        string FlightNumber,
        //                                        int DepartCityId,
        //                                        DateTime DepartDate,
        //                                        string DepartTime,
        //                                        int ArriveCityId,
        //                                        DateTime ArriveDate,
        //                                        string ArriveTime,
        //                                        string BIC,
        //                                        string StartTerminal,
        //                                        string EndTerminal,
        //                                        string AirlineRefrenceNumber,
        //                                        int CreatedBy,
        //                                        DateTime CreatedDate)
        //{
        //    var obj = new PNRSegments
        //    {
        //        PNRId = PNRId,
        //        SectorId = SectorId,
        //        AirlineId = AirlineId,
        //        FlightNumber = FlightNumber,
        //        DepartCityId = DepartCityId,
        //        DepartDate = DepartDate,
        //        DepartTime = TimeSpan.Parse(DepartTime),
        //        ArriveCityId = ArriveCityId,
        //        ArriveDate = ArriveDate,
        //        ArriveTime = TimeSpan.Parse(ArriveTime),
        //        BIC = BIC,
        //        StartTerminal = StartTerminal,
        //        EndTerminal = EndTerminal,
        //        AirlineRefrenceNumber = AirlineRefrenceNumber,
        //        CreatedBy = CreatedBy,
        //        CreatedDate = CreatedDate
        //    };

        //    entity.AddToPNRSegments(obj);
        //    entity.SaveChanges();
        //}

        //public Int64 SavepassangerInformation(Int64 PNRId,
        //                                   string Prefix,
        //                                   string FirstName,
        //                                   string MiddleName,
        //                                   string LastName,
        //                                   DateTime DOB,
        //                                   string PassportNumber,
        //                                   int? Nationality,
        //                                   DateTime? PassportExpDate,
        //                                   string MobileNumber,
        //                                   string EmailAddress,
        //                                   int PassengerTypeId,
        //                                   decimal Fare,
        //                                   double FSC,
        //                                   double MarkupAmount,
        //                                   double TaxAmount,
        //                                   double CommissionAmount,
        //                                   string TicketNumber,
        //                                   int TicketStatusId,
        //                                   string FrequentFlierNo,
        //                                   string SSR,
        //                                   string OtherSSRCode,
        //                                   string DOCS,
        //                                   string DOCO,
        //                                   string DOCA,
        //                                   string OSI,
        //                                   int? AirlineId,
        //                                   int CreatedBy,
        //                                   DateTime CreatedDate,
        //                                   decimal AgentMarkup)
        //{
        //    var obj = new Passengers
        //    {
        //        PNRId = PNRId,
        //        Prefix = Prefix,
        //        FirstName = FirstName,
        //        MiddleName = MiddleName,
        //        LastName = LastName,
        //        DOB = new DateTime(2011, 1, 12),//DOB, Change it ASAP
        //        PassportNumber = PassportNumber,
        //        PassportExpDate = PassportExpDate,
        //        Nationality = Nationality > 0 ? Nationality : null,
        //        MobileNumber = MobileNumber,
        //        EmailAddress = EmailAddress,
        //        PassengerTypeId = PassengerTypeId,
        //        Fare = (double)Fare,
        //        FSC = FSC,
        //        MarkupAmount = MarkupAmount,
        //        TaxAmount = TaxAmount,
        //        CommissionAmount = CommissionAmount,
        //        TicketNumber = TicketNumber,
        //        TicketStatusId = TicketStatusId,
        //        FrequentFlierNo = FrequentFlierNo != "" ? FrequentFlierNo : null,
        //        SSR = SSR != "Select" ? SSR : null,
        //        OtherSSRCode = OtherSSRCode != "Select" ? OtherSSRCode : null,
        //        DOCS = DOCS,
        //        DOCO = DOCO,
        //        DOCA = DOCA,
        //        OSI = OSI,
        //        AirlineId = AirlineId > 0 ? AirlineId : null,
        //        CreatedBy = CreatedBy,
        //        CreatedDate = CreatedDate,
        //        ServiceCharge = (double)AgentMarkup

        //    };

        //    entity.AddToPassengers(obj);
        //    entity.SaveChanges();
        //    return obj.PassengerId;
        //}


        //public void SaveAir_Taxes(Int64 passangerId, string taxName, decimal taxAmount)
        //{
        //    var obj = new Air_Taxes
        //    {
        //        PassengerId = passangerId,
        //        TaxName = taxName,
        //        TaxAmount = (double)taxAmount
        //    };

        //    entity.AddToAir_Taxes(obj);
        //    entity.SaveChanges();
        //}

        //public IQueryable<GetPNRsListByAgentId_Result> GetPNRsListByAgentId(int TicketStatusId, int AgentId)
        //{
        //    return entity.GetPNRsListByAgentId(TicketStatusId, AgentId).AsQueryable();
        //}



        public Int64 SavePNRInformation(int AgentId,
                                           int ServiceProviderId,
                                           Salutation Prefix,
                                           string FirstName,
                                           string MiddleName,
                                           string LastName,
                                           string Email,
                                           string ContactNumber,
                                           string GDSRefrenceNumber,
                                           int TicketStatusId,
                                           int CreatedBy,
                                           DateTime CreatedDate,
                                           DateTime? TTL,
                                           DateTime? ATLTTL,
                                           string pcc
                                       )
        {
            var obj = new PNRs
            {
                AgentId = AgentId,
                ServiceProviderId = ServiceProviderId,
                Prefix = Prefix.ToString(),
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                EmailAddress = Email,
                ContactNumber = ContactNumber,
                GDSRefrenceNumber = GDSRefrenceNumber,
                TicketStatusId = TicketStatusId,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate,
                TTL = TTL,
                ATLTTL = ATLTTL,
                PCC = pcc
            };

            entity.AddToPNRs(obj);
            entity.SaveChanges();

            return obj.PNRId;
        }



        public Int64 SavePNRSectorInformation(int platingCarrierId,
                                          Int64 PNRId,
                                          int DepartureCityId,
                                          DateTime DepartureDate,
                                          string DepartureTime,
                                          int DestinationCityId,
                                          DateTime ArriveDate,
                                          string ArriveTime,
                                          string StartTerminal,
                                          string EndTerminal,
                                          int CreatedBy,
                                          DateTime CreatedDate)
        {
            var obj = new PNRSectors
            {
                PlatingCarrierId = platingCarrierId,
                PNRId = PNRId,
                DepartCityId = DepartureCityId,
                DepartDate = DepartureDate,
                DepartTime = TimeSpan.Parse(DepartureTime),
                DestinationCityId = DestinationCityId,
                ArriveDate = ArriveDate,
                ArriveTime = TimeSpan.Parse(ArriveTime),
                StartTerminal = StartTerminal,
                EndTerminal = EndTerminal,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate
            };

            entity.AddToPNRSectors(obj);
            entity.SaveChanges();

            return obj.SectorId;
        }


        public void SavePNRSegmentInformation(Int64 PNRId,
                                                Int64 SectorId,
                                                int AirlineId,
                                                string FlightNumber,
                                                int DepartCityId,
                                                DateTime DepartDate,
                                                string DepartTime,
                                                int ArriveCityId,
                                                DateTime ArriveDate,
                                                string ArriveTime,
                                                string BIC,
                                                string StartTerminal,
                                                string EndTerminal,
                                                string AirlineRefrenceNumber,
                                                string VndRemark,
                                                int CreatedBy,
                                                DateTime CreatedDate,
                                                string FIC,
                                                int FlightTime,
                                                DateTime? NVA,
                                                DateTime? NVB
            )
        {
            var obj = new PNRSegments
            {
                PNRId = PNRId,
                SectorId = SectorId,
                AirlineId = AirlineId,
                FlightNumber = FlightNumber,
                DepartCityId = DepartCityId,
                DepartDate = DepartDate,
                DepartTime = TimeSpan.Parse(DepartTime),
                ArriveCityId = ArriveCityId,
                ArriveDate = ArriveDate,
                ArriveTime = TimeSpan.Parse(ArriveTime),
                BIC = BIC,
                StartTerminal = StartTerminal,
                EndTerminal = EndTerminal,
                AirlineRefrenceNumber = AirlineRefrenceNumber,
                VndRemarks = VndRemark,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate,
                FIC = FIC,
                FlightDuration = FlightTime,
                NVA = NVA,
                NVB = NVB
            };

            entity.AddToPNRSegments(obj);
            entity.SaveChanges();
        }

        public Int64 SavepassangerInformation(Int64 PNRId,
                                           Salutation Prefix,
                                           string FirstName,
                                           string MiddleName,
                                           string LastName,
                                           DateTime? DOB,
                                           string PassportNumber,
                                           int? Nationality,
                                           DateTime? PassportExpDate,
                                           string MobileNumber,
                                           string EmailAddress,
                                           int PassengerTypeId,
                                           decimal Fare,
                                           double FSC,
                                           double MarkupAmount,
                                           double TaxAmount,
                                           double CommissionAmount,
                                            double DiscountAmount,
                                           string TicketNumber,
                                           int TicketStatusId,
                                           string FrequentFlierNo,
                                           string SSR,
                                           string OtherSSRCode,
                                           string DOCS,
                                           string DOCO,
                                           string DOCA,
                                           string OSI,
                                           int? AirlineId,
                                           int CreatedBy,
                                           DateTime CreatedDate,
                                           decimal? AgentMarkup,
                                           CurrencyType currency)
        {
            var obj = new Passengers
            {
                PNRId = PNRId,
                Prefix = Prefix.ToString(),
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                DOB = DOB,
                PassportNumber = PassportNumber,
                PassportExpDate = PassportExpDate,
                Nationality = Nationality > 0 ? Nationality : null,
                MobileNumber = MobileNumber,
                EmailAddress = EmailAddress,
                PassengerTypeId = PassengerTypeId,
                Fare = (double)Fare,
                FSC = FSC,
                MarkupAmount = MarkupAmount,
                TaxAmount = TaxAmount,
                CommissionAmount = CommissionAmount,
                DiscountAmount = DiscountAmount,
                TicketNumber = TicketNumber,
                TicketStatusId = TicketStatusId,
                FrequentFlierNo = FrequentFlierNo != "" ? FrequentFlierNo : null,
                SSR = SSR != "Select" ? SSR : null,
                OtherSSRCode = OtherSSRCode != "Select" ? OtherSSRCode : null,
                DOCS = DOCS,
                DOCO = DOCO,
                DOCA = DOCA,
                OSI = OSI,
                AirlineId = AirlineId > 0 ? AirlineId : null,
                CreatedBy = CreatedBy,
                CreatedDate = CreatedDate,
                ServiceCharge = (double)AgentMarkup,
                Currency = currency.ToString()
            };

            entity.AddToPassengers(obj);
            entity.SaveChanges();
            return obj.PassengerId;
        }

        public void SaveAir_Taxes(Int64 passangerId, string taxName, decimal taxAmount)
        {
            var obj = new Air_Taxes
            {
                PassengerId = passangerId,
                TaxName = taxName,
                TaxAmount = (double)taxAmount
            };

            entity.AddToAir_Taxes(obj);
            entity.SaveChanges();
        }

        public void SaveAir_AirlineVendorLocators(Int64 PNRId, string AirlineCode, string VendorLocator, string VendorRemarks, DateTime ReceivedOnDate, string ReceivedTime)
        {
            var obj = new Air_AirlineVendorLocators
            {
                PNRId = PNRId,
                AirlineCode = AirlineCode,
                VendorLocatorNo = VendorLocator,
                VendorRemark = VendorRemarks,
                ReceivedOnDate = ReceivedOnDate,
                ReceivedTime = TimeSpan.Parse(ATLTravelPortal.Helpers.TimeFormat.GetFormattedTime(ReceivedTime))
            };
            entity.AddToAir_AirlineVendorLocators(obj);
            entity.SaveChanges();
        }

        public IQueryable<GetPNRsListByAgentId_Result> GetPNRsListByAgentId(int TicketStatusId, int AgentId)
        {
            return entity.GetPNRsListByAgentId(TicketStatusId, AgentId).AsQueryable();
        }

        public Galileo.PnrService.DisplayRetrievePNR GetPNRResult(Int64 AgentId, string RecordLocator)
        {
            //EntityModel entity = new EntityModel();
            var pnrs = entity.PNRs.Where(x => x.AgentId == AgentId && x.GDSRefrenceNumber == RecordLocator).FirstOrDefault();
            if (pnrs == null)
                throw new Exception("Unauthorized Agent.");

            Galileo.PnrService.BookingManager tktBokManager = new Galileo.PnrService.BookingManager();
            return tktBokManager.RetrievePNR(RecordLocator);
        }

        public Galileo.PnrService.DisplayRetrievePNR CancelPnr(int AgentId, string Issuer, string RecordLocator)
        {
            // EntityModel entity = new EntityModel();
            var pnrs = entity.PNRs.Where(x => x.AgentId == AgentId && x.GDSRefrenceNumber == RecordLocator).FirstOrDefault();
            if (pnrs == null)
                throw new Exception("Unauthorized Agent.");

            Galileo.PnrService.BookingManager tktBokManager = new Galileo.PnrService.BookingManager();
            Galileo.PnrService.DisplayRetrievePNR cancelResponse = tktBokManager.CancelPnr(RecordLocator, Issuer, Galileo.PnrService.SegmentCancellation.All);
            //entity.Air_CancelTickets(pnrs.PNRId, AgentId);
            return cancelResponse;
        }

        public void AirSaveTicketStatusLogs(Int64 PNRId, int TicketStatusId, int MakerId)
        {
            // EntityModel entity = new EntityModel();
            entity.Air_SaveTicketStatusLogs(PNRId, TicketStatusId, MakerId);
        }

        public void Air_IssueTickets(Int64 PNRId, int MakerId)
        {
            entity.Air_IssueTickets(PNRId, MakerId);
        }

        public void TBO_Air_IssueTickets(Int64 PNRId, int MakerId)
        {
            entity.TBO_Air_IssueTickets(PNRId, MakerId);
        }

        public StringBuilder GetMesseageIfNotConfirmed(PNRRetrieveResult pnrResponse)
        {
            StringBuilder builder = new StringBuilder();

            if (pnrResponse.segList != null)
            {
                foreach (var segment in pnrResponse.segList)
                {
                    if (segment.Status != "HK")
                    {
                        builder.Append(segment.StatusExplanation);
                    }
                }
            }
            return builder;
        }


        public void UpdateAir_AirlineVendorLocators(Galileo.PnrService.DisplayRetrievePNR result, Int64 AgentId, string RecordLocator)
        {
            PNRInfoProvider pnrInfoProvider = new PNRInfoProvider();
            bool IsChanged = false;
            var Pnrs = entity.PNRs.Where(x => x.AgentId == AgentId && x.GDSRefrenceNumber == RecordLocator);
            foreach (PNRs pnr in Pnrs)
            {
                foreach (var vndRec in result.VendorRecordLocatorList)
                {
                    var Air_AirlineVendorLocators = entity.Air_AirlineVendorLocators.Where(x => x.PNRId == pnr.PNRId &&
                                                                                            x.AirlineCode == vndRec.Vendor &&
                                                                                                x.VendorLocatorNo == vndRec.RecordLocator);

                    if (Air_AirlineVendorLocators.FirstOrDefault() == null)
                    {
                        var obj = new Air_AirlineVendorLocators
                        {
                            PNRId = pnr.PNRId,
                            AirlineCode = vndRec.Vendor,
                            VendorLocatorNo = vndRec.RecordLocator,
                            VendorRemark = null,
                            ReceivedOnDate = vndRec.DtStamp,
                            ReceivedTime = TimeSpan.Parse(ATLTravelPortal.Helpers.TimeFormat.GetFormattedTime(vndRec.TmStamp))
                        };
                        entity.AddToAir_AirlineVendorLocators(obj);
                        IsChanged = true;
                    }
                }
            }
            if (IsChanged)
                entity.SaveChanges();
        }


        public IEnumerable<Air_GetToRetrivePNRs_Result> Air_GetToRetrivePNRs(int AgentId)
        {
            return entity.Air_GetToRetrivePNRs(AgentId);
        }



        public List<PNRRetrieveResult> ListVendorLocator(int AgentId)
        {
            var data = entity.Air_GetToRetrivePNRs(AgentId);

            List<PNRRetrieveResult> model = new List<PNRRetrieveResult>();

            foreach (var item in data.Select(x => x))
            {
                var PNRRetrieveResult = new PNRRetrieveResult
                {
                    PNRId = item.PNRId,
                    GDSReferenceNumber = item.GDSRefrenceNumber,
                    PassengerName = item.PassengerName,
                    Sector = item.Sector

                };
                model.Add(PNRRetrieveResult);

            }
            return model.ToList();
        }


        //for pagination//
        public IQueryable<PNRRetrieveResult> GetVendorLocatorByPagination(PNRRetrieveResult m, int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {

            int pageSize = 30; //(int)AirLines.Helpers.PageSize.JePageSize;
            int rowCount = m.VendorLocatorList.Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<PNRRetrieveResult> pagingdata = m.VendorLocatorList.Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata.AsQueryable();


        }

        public string TransferPNRToAgency(int AgentId, int ToAgentId, string GDSNo, string Type, string Remark, int MakerId)
        {
             int response=0;
             string Message = string.Empty;
            try
            {
                 response = entity.Air_PNRAgencyTransfer(AgentId, ToAgentId, GDSNo, Type, Remark, MakerId);
                 GeneralProvider defaultProvider = new GeneralProvider();
                 var Agentinfo = defaultProvider.GetAgentById(ToAgentId);
                 Message = " PNR No [" + GDSNo + "] successufully transfered from Arihant Holidays to " + Agentinfo.AgentName;
                return Message;
            }
            catch(Exception ex)
            {
                return ex.InnerException.Message;
            }
        }




    }
}