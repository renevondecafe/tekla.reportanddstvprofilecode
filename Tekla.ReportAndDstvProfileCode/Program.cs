using System;
using TSM = Tekla.Structures.Model;

namespace Tekla.ReportAndDstvProfileCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var picker = new TSM.UI.Picker();
            var result = picker.PickObject(TSM.UI.Picker.PickObjectEnum.PICK_ONE_PART);

            TSM.Part part = result as TSM.Part;

            string profileType = null;
            part.GetReportProperty("PROFILE_TYPE", ref profileType);

            string dstv = string.Empty;
            bool success = TSM.Operations.Operation.CreateNCFilesByPartId("DSTV - Shafts", "", part.Identifier, out dstv);

            string[] dstvLines = dstv.Split(new string[] { "\n" }, StringSplitOptions.None);

            string dstvCode = dstvLines[9].Trim();

            Console.WriteLine($"PROFILE_TYPE: {profileType}");
            Console.WriteLine($"DSTV CODE: {dstvCode}");
            Console.ReadKey();
        }
    }
}