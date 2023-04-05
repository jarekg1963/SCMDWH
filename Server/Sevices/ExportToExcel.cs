using ClosedXML.Excel;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Microsoft.CodeAnalysis.Differencing;
using NPOI.SS.UserModel;
using SCMDWH.Server.Data;
using SCMDWH.Shared.Models;
using System.Data.Entity;

namespace SCMDWH.Server.Sevices
{
    public class ExportToExcel
    {

        private readonly CarAdviceContext _context;

        public ExportToExcel(CarAdviceContext context)
        {
            _context = context;
        }


        public byte[] CreateExcelExport(string UserName)
        {
            var workbook = new XLWorkbook();
            workbook.Properties.Title = "Export from CA";
            workbook.Properties.Author = "MG";
            workbook.Properties.Subject = "Export from CA";
            workbook.Properties.Keywords = "CA, TPV , blazor";

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


        public void setupCelStyle(int ro , int co)
        {

        }
        public void CreateAuthorWorksheet(XLWorkbook package, string UserName)
        {
            List<CarAdviceMainTable> carListToExcel = new List<CarAdviceMainTable>();
            var worksheet = package.Worksheets.Add("CA");
            var datyDoRaportu = _context.GlobalAppUsersParameters.Where(c => c.UserName == UserName).FirstOrDefault();
            var headerList = _context.CarAdviceMainPlanComum.Where(c=>c.UserName == UserName).OrderBy(o=>o.OrderColumn).ToList();
            int i = 1;
            foreach (var header in headerList)
            {
                if (header.Hidden == false)
                {
                    worksheet.Cell(1, i).Style.Font.SetBold(true);
                    worksheet.Cell(1, i).Style.Fill.BackgroundColor = XLColor.CoolGrey;
                    worksheet.Cell(1, i).Value = header.plHeader;
                    i++;
                }
            }
            carListToExcel = _context.CarAdviceMainTables.Where(d => d.Etd >= datyDoRaportu.DateMainCAFrom && d.Etd <= datyDoRaportu.DateMainCATo)
               .OrderByDescending(c => c.Id).ToList();
            int index = 1;
            foreach (var item in carListToExcel)
            {
                int j = 1;
                foreach (var header in headerList)
                {

                    worksheet.Cell(index+1, j).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(index+1, j).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(index+1, j).Style.Border.RightBorder = XLBorderStyleValues.Thin;

                    if (header.MainScreenColumn == "Id" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Id;
                        j++;
                    }
                    if (header.MainScreenColumn == "AdviceDate" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.AdviceDate;
                        j++;
                    }
                    if (header.MainScreenColumn == "FgDelayReason" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.FgDelayReason;
                        j++;
                    }
                    if (header.MainScreenColumn == "PickingStatus" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.PickingStatus;
                        j++;
                    }
                    if (header.MainScreenColumn == "Client" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Client;
                        j++;
                    }
                    if (header.MainScreenColumn == "Shipment" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Shipment;
                        j++;
                    }
                    if (header.MainScreenColumn == "Reference" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Reference;
                        j++;
                    }
                    if (header.MainScreenColumn == "Destination" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Destination;
                        j++;
                    }
                    if (header.MainScreenColumn == "DriverWh" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.DriverWh;
                        j++;
                    }

                    if (header.MainScreenColumn == "TruckPlatesWh" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.TruckPlatesWh;
                        j++;
                    }

                    if (header.MainScreenColumn == "Forwarder" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Forwarder;
                        j++;
                    }
                    if (header.MainScreenColumn == "Etd" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Etd;
                        j++;
                    }
                    if (header.MainScreenColumn == "EntryByWh" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.EntryByWh;
                        j++;
                    }
                    if (header.MainScreenColumn == "Ata" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Ata;
                        j++;
                    }
                    if (header.MainScreenColumn == "Quality" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.Quality;
                        j++;
                    }
                    if (header.MainScreenColumn == "TruckType" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.TruckType;
                        j++;
                    }
                    if (header.MainScreenColumn == "DriverS" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.DriverS;
                        j++;
                    }
                    if (header.MainScreenColumn == "TpvEnterTime" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.TpvEnterTime;
                        j++;
                    }
                    if (header.MainScreenColumn == "TpvExitTime" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.TpvExitTime;
                        j++;
                    }
                    if (header.MainScreenColumn == "LoadingDock" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.LoadingDock;
                        j++;
                    }
                    if (header.MainScreenColumn == "CallBy" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.CallBy;
                        j++;
                    }
                    if (header.MainScreenColumn == "RemarksS" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.RemarksS;
                        j++;
                    }
                    if (header.MainScreenColumn == "EntryByS" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.EntryByS;
                        j++;
                    }
                    if (header.MainScreenColumn == "LeftTheDockTime" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.LeftTheDockTime;
                        j++;
                    }
                    if (header.MainScreenColumn == "PickingTime" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.PickingTime;
                        j++;
                    }
                    if (header.MainScreenColumn == "ScannedTime" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.ScannedTime;
                        j++;
                    }
                    if (header.MainScreenColumn == "ForwarderInfo" && header.Hidden == false)
                    {
                        worksheet.Cell(index + 1, j).Value = item.ForwarderInfo;
                        j++;
                    }
              
                }
                index++;
              
            }
           
        }
    }
}
