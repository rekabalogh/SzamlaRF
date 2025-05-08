using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rendeleskezelo;
using System.IO;
using System.Windows.Forms;
// Removed: using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExample.Test
{
    internal class teszt
    {
        [Test]
        public void Test_GenerateXmlFile_CreatesFileWithContent()
        {
            // Arrange
            var form = new MainForm();

            // DataGridView elérése publikus property-n keresztül
            var grid = form.OrdersGrid;

            // Oszlopok hozzáadása, ha nincsenek (teszt közben nem automatikus)
            if (grid.Columns.Count == 0)
            {
                grid.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "checkBox" });
                grid.Columns.Add("orderId", "OrderId");
                grid.Columns.Add("customerName", "Customer Name");
                grid.Columns.Add("email", "Email");
                grid.Columns.Add("orderDate", "Order Date");
                grid.Columns.Add("shippingAddress", "Shipping Address");
                grid.Columns.Add("orderTotal", "Order Total");
            }

            // Sor hozzáadása, bejelölve (checkbox = true)
            grid.Rows.Add(true, "123", "Teszt Elek", "teszt@valami.hu", "2025-01-01", "Teszt utca 1", "1500");

            // Teszt fájlnév
            string filePath = "teszt.xml";
            if (File.Exists(filePath))
                File.Delete(filePath);

            // Act
            form.GenerateXMLToFile(filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath), "Nem jött létre az XML fájl.");
            string content = File.ReadAllText(filePath);
            Assert.IsTrue(content.Contains("Teszt Elek"), "A fájl nem tartalmazza a várt adatokat.");
        }
    }
}
