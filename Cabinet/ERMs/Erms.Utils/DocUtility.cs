using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Interface;
using Spire.Doc.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erms.Utils
{
    public class DocUtility
    {
        public DocUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void MergeFile(DataSet ds, System.Collections.Generic.List<System.Collections.DictionaryEntry> list, string tempFile, string destFile)
        {
            Document document = new Document();
            document.LoadFromFile(tempFile, FileFormat.Doc);

            //index of row of merged order data
            int mergedRowIndex = 0;
            document.MailMerge.MergeField += delegate (object sender, MergeFieldEventArgs e)
            {
                if (e.TableName == ds.Tables[0].TableName)
                {
                    if (e.RowIndex > mergedRowIndex)
                    {
                        mergedRowIndex = e.RowIndex;

                        //insert page break symbol before the paragraph of current field
                        InsertPageBreak(e.CurrentMergeField);
                    }
                }
            };

            //clear empty value fields during merge process
            document.MailMerge.ClearFields = true;

            //clear empty paragraphs if it has only empty value fields.
            document.MailMerge.HideEmptyParagraphs = true;

            //merge      
            if (list.Count > 0)
                document.MailMerge.ExecuteWidthNestedRegion(ds, list);
            else
                document.MailMerge.Execute(ds.Tables[0]);

            //set word view type.
            document.ViewSetup.DocumentViewType = DocumentViewType.PrintLayout;
            document.SaveToFile(destFile);
            //System.Diagnostics.Process.Start("Invoice.doc");
        }

        private static void InsertPageBreak(IMergeField field)
        {
            //append a page break symbol
            Break pageBreak = field.OwnerParagraph.AppendBreak(BreakType.PageBreak);
            //move to the start of the paragraph
            field.OwnerParagraph.Items.Insert(0, pageBreak);
        }
    }
}
