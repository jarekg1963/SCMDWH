using ClosedXML.Excel;
using NPOI.SS.UserModel;
using SCMDWH.Server.Data;

namespace SCMDWH.Server.Sevices
{
    public class ExportToExcel
    {

        private readonly PurchasingContext _context;

        public ExportToExcel(PurchasingContext context)
        {
            _context = context;
        }


        public byte[] CreateAuthorExport(string UserName)
        {
            var workbook = new XLWorkbook();
            workbook.Properties.Title = "Export from asn";
            workbook.Properties.Author = "JG";
            workbook.Properties.Subject = "Export from ASN";
            workbook.Properties.Keywords = "asn, sky , blazor";

            CreateAuthorWorksheet(workbook, UserName);

            return ConvertToByte(workbook);
        }

        private byte[] ConvertToByte(XLWorkbook workbook)
        {
            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();
            return content;
        }

        public void CreateAuthorWorksheet(XLWorkbook package, string UserName)
        {

            //SkyAsnHeader hh = new SkyAsnHeader();
            //hh = _context.SkyAsnHeaders.Include(s => s.SkyAsnItems).Where(d => d.OemShipmentNumberTpvDn == DnNr).FirstOrDefault();


            var listToExpor = _context.CarAdviceMainTable.ToList();
            var worksheet = package.Worksheets.Add("CA");


            #region wczytanie dat do raportu 

            var datyDoRaportu = _context.GlobalAppUsersParameters.Where(c => c.UserName == UserName).FirstOrDefault();

            #endregion wczytanie dat do raportu 



            #region Zaczytanie nagłowków 

            var headerList = _context.CarAdviceMainPlanComum.Where(c=>c.UserName == UserName).ToList();

            int i = 1;
            foreach ( var header in headerList ) 
            {
                worksheet.Cell(1, i).Value = header.MainScreenColumn;

                //worksheet.Cell(1, 1).Value = "Id";
                //worksheet.Cell(1, 2).Value = "TvSerialNumber";

            }

            #endregion Zaczytania nagłowków

            
            #region zaczytanie rekordow 


            #endregion zaczytanie rekordow 


            int index = 1;
            //foreach (var item in hh.SkyAsnItems)
            //{
            //    worksheet.Cell(index + 1, 1).Value = item.Id;
            //    worksheet.Cell(index + 1, 2).Value = item.TvSerialNumber;
            //    worksheet.Cell(index + 1, 3).Value = item.DeviceSerialNumber;
            //    worksheet.Cell(index + 1, 4).Value = item.ManufacturersInternalSerialNumber;
            //    worksheet.Cell(index + 1, 5).Value = item.EthernetMac;
            //    worksheet.Cell(index + 1, 6).Value = item.WifiMac;
            //    worksheet.Cell(index + 1, 7).Value = item.Wifi24Mac;
            //    worksheet.Cell(index + 1, 8).Value = item.BluetoothMac;

            //    worksheet.Cell(index + 1, 9).Value = item.SocId.ToString();
            //    worksheet.Cell(index + 1, 9).Style.NumberFormat.SetNumberFormatId((int)XLPredefinedFormat.Number.Integer);
            //    worksheet.Cell(index + 1, 10).Value = item.FirmwareVer;
            //    worksheet.Cell(index + 1, 11).Value = item.HardwareVer;
            //    worksheet.Cell(index + 1, 12).Value = item.DeviceStatus;
            //    worksheet.Cell(index + 1, 13).Value = item.MasterCartonId;
            //    worksheet.Cell(index + 1, 14).Value = item.PalletNo;
            //    worksheet.Cell(index + 1, 15).Value = item.WpsPin;
            //    worksheet.Cell(index + 1, 16).Value = item.SkyInitialPciversion;
            //    worksheet.Cell(index + 1, 17).Value = item.SkyInitialPdriversion;
            //    worksheet.Cell(index + 1, 18).Value = item.SkyInitialBdriversion;
            //    worksheet.Cell(index + 1, 19).Value = item.SkyPsuSn;
            //    worksheet.Cell(index + 1, 20).Value = item.SkyRcutype;
            //    worksheet.Cell(index + 1, 21).Value = item.LcmSn;
            //    worksheet.Cell(index + 1, 22).Value = item.PowerBoardSn;
            //    worksheet.Cell(index + 1, 23).Value = item.DriverBoardSn;
            //    worksheet.Cell(index + 1, 24).Value = item.TconNs;
            //    worksheet.Cell(index + 1, 25).Value = item.TlUpfireSn;
            //    worksheet.Cell(index + 1, 26).Value = item.TrUpfireSn;
            //    worksheet.Cell(index + 1, 27).Value = item.SoundModuleSn;
            //    worksheet.Cell(index + 1, 28).Value = item.RfBoardSn;
            //    worksheet.Cell(index + 1, 29).Value = item.IrBoardSn;
            //    worksheet.Cell(index + 1, 30).Value = item.SkyTunerBoardSn;
            //    index++;
            //}

        }


        }
}
