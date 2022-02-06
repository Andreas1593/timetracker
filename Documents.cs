using MigraDoc.DocumentObjectModel;

namespace timetracker
{
    class Documents
    {
        public static Document CreateDocument(string[] lines)
        {
            // Create a new MigraDoc document.
            var document = new Document();
            document.Info.Title = "Time Tracker PDF export";
            document.Info.Subject = "Shows the time spent on a project";

            Styles.DefineStyles(document);

            DefineContentSection(document);

            Tables.SimpleTable(document, lines);

            return document;
        }

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        static void DefineContentSection(Document document)
        {
            var section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            // Create a paragraph with centered page number. See definition of style "Footer".
            var paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }
    }
}