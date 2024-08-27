using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
//using OfficeOpenXml;
//using OfficeOpenXml.DataValidation;
//using OfficeOpenXml.Style;

namespace Aurora.Services.OrderManagement.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        [HttpGet("list")]
        public async Task<ActionResult<string>> GetOrderList()
        {

            return Ok("success");

        }


        //public IActionResult ExportTemplate()
        //{
        //    // Set the license context
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    var clients = new List<string> { "Client1", "Client2", "Client3" }; // Replace with your client list

        //    using (var package = new ExcelPackage())
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("Template");

        //        // Add column headers
        //        worksheet.Cells[1, 1].Value = "FirstName";
        //        worksheet.Cells[1, 2].Value = "LastName";
        //        worksheet.Cells[1, 3].Value = "Client";

        //        // Add dropdown list for the Client column
        //        var clientRange = worksheet.Cells[2, 3, 1000, 3]; // Adjust the range as needed
        //        var validation = clientRange.DataValidation.AddListDataValidation();

        //        foreach (var client in clients)
        //        {
        //            validation.Formula.Values.Add(client);
        //        }

        //        // Configure the validation to show an error message if a value outside the dropdown is entered
        //        validation.ShowErrorMessage = true;
        //        validation.ErrorTitle = "Invalid Value";
        //        validation.Error = "Please select a value from the list.";
        //        validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;

        //        // Style header
        //        using (var range = worksheet.Cells[1, 1, 1, 3])
        //        {
        //            range.Style.Font.Bold = true;
        //            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        }

        //        worksheet.Columns[1, 3].AutoFit();

        //        var stream = new MemoryStream(package.GetAsByteArray());
        //        var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        var fileName = "Template.xlsx";

        //        return File(stream, contentType, fileName);
        //    }
        //}
        [HttpGet("export-template")]
        public IActionResult ExportTemplate()
        {
            var clients = new List<string> { "Client1", "Client2", "Client3" }; // Replace with your client list

            // Create a new workbook and sheet
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Template");

            // Create header row
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("FirstName");
            headerRow.CreateCell(1).SetCellValue("LastName");
            headerRow.CreateCell(2).SetCellValue("Client");

            // Create a data validation constraint for the "Client" column
            var dvHelper = sheet.GetDataValidationHelper();
            var dvConstraint = dvHelper.CreateExplicitListConstraint(clients.ToArray());
            var cellRangeAddressList = new CellRangeAddressList(1, 999, 2, 2); // Apply the validation to the "Client" column
            var validation = dvHelper.CreateValidation(dvConstraint, cellRangeAddressList);

            // Enable the error box to prevent invalid values
            validation.ShowErrorBox = true;

            // Add the validation to the sheet
            sheet.AddValidationData(validation);

            // Auto-size the columns
            for (int i = 0; i < 3; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                var content = stream.ToArray();
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "Template.xlsx";

                return File(content, contentType, fileName);
            }
        }
    }
}
