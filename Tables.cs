using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace timetracker
{
    /// <summary>
    /// This class demonstrates MigraDoc tables.
    /// </summary>
    public class Tables
    {
        public static void SimpleTable(Document document, string[] lines)
        {
            document.LastSection.AddParagraph(lines[0], "Heading1");

            var table = new Table();
            table.Borders.Width = 0.75;

            var column = table.AddColumn(Unit.FromCentimeter(5));
            // column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(5));

            table.AddColumn(Unit.FromCentimeter(5));

            int total = 0;

            foreach (string line in lines.Skip(1))
            {
                // Prevent IndexOutOfRangeException
                if (line.Length > 17)
                {
                    var row = table.AddRow();
                    row.Shading.Color = Colors.FloralWhite;

                    var cell = row.Cells[0];
                    cell.AddParagraph(line[..10]);

                    cell = row.Cells[1];
                    cell.AddParagraph(line.Substring(11, 5));

                    cell = row.Cells[2];
                    try
                    {
                        cell.AddParagraph(Form1.formatTime(Int32.Parse(line[17..])));
                    }
                    catch
                    {
                        cell.AddParagraph("Corrupt file");
                    }

                    total += Int32.Parse(line[17..]);
                }
            }

            var rowTotal = table.AddRow();
            rowTotal.Shading.Color = Colors.Gainsboro;

            var cellTotal = rowTotal.Cells[0];
            cellTotal.Borders.Right.Width = 0;

            cellTotal = rowTotal.Cells[1];
            cellTotal.Borders.Left.Width = 0;
            cellTotal.Borders.Right.Width = 0;
            cellTotal.AddParagraph("Total:");
            cellTotal.Format.Font.Bold = true;

            cellTotal = rowTotal.Cells[2];
            cellTotal.Borders.Left.Width = 0;
            cellTotal.AddParagraph(Form1.formatTime(total));
            cellTotal.Format.Font.Bold = true;

            // First args: colBegin, rowBegin, countCols, countRows, ...
            table.SetEdge(0, 0, 3, lines.Length, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1, Colors.Black);

            document.LastSection.Add(table);
        }
    }
}