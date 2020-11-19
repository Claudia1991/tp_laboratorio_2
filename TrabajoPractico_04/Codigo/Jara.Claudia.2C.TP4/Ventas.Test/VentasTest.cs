using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ventas.DAO;
using Ventas.Modelos.DataModels;

namespace Ventas.Test
{
    [TestClass]
    public class VentasTest
    {
        private VentasDao ventasDao;
        private VentaDataModel venta;

        [TestInitialize]
        public void TestInitializer()
        {
            ventasDao = new VentasDao();

            venta = new VentaDataModel()
            {
                Fecha = DateTime.Now,
                MontoTotal = 1000,
                DetalleVenta = new VentaDetalleDataModel()
                {
                    Productos = new System.Collections.Generic.List<ProductoDetalleDataModel>()
                    {
                        new ProductoDetalleDataModel(1, "Test",1000,1,1000)
                    }
                }
            };
        }

        [TestMethod]
        public void VentaDao_CreateElement_TestMethod()
        {
            venta = new VentaDataModel() 
            {
                Fecha = DateTime.Now,
                MontoTotal = 1000,
                DetalleVenta = new VentaDetalleDataModel() 
                {
                    Productos = new System.Collections.Generic.List<ProductoDetalleDataModel>() 
                    {
                        new ProductoDetalleDataModel(1, "Test",1000,1,1000)
                    }
                }
            };

            

            Assert.IsTrue(ventasDao.CreateElement(venta));
        }

        [TestMethod]
        public void VentaDao_GetAllElements_TestMethod()
        {
            List<VentaDataModel> ventaDataModel;
            ventaDataModel = ventasDao.GetAllElements();
            Assert.IsNotNull(ventaDataModel);
        }

        [TestMethod]
        public void VentaDao_GetElementById_TestMethod()
        {
            VentaDataModel ventaDataModel;
            ventaDataModel = ventasDao.GetElementById(ventasDao.GetMaxId());
            Assert.IsNotNull(ventaDataModel);
        }

        [TestMethod]
        public void VentaDao_UpdateElement_TestMethod()
        {
            venta.Id = ventasDao.GetMaxId();
            venta.Fecha = DateTime.Now.AddDays(3);
            Assert.IsTrue(ventasDao.UpdateElement(venta));
        }

        [TestMethod]
        public void VentaDao_DeleteElementById_TestMethod()
        {
            Assert.IsTrue(ventasDao.DeleteElementById(ventasDao.GetMaxId()));
        }
    }
}
