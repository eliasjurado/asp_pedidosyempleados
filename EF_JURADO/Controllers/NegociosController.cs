using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities;
using Dominio.MainModule;
using EF_JURADO.Reportes;
using ReportViewerForMvc;

using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;


namespace EF_JURADO.Controllers
{
    public class NegociosController : Controller
    {
        PedidoManager ped = new PedidoManager();
        EmpleadoManager emp = new EmpleadoManager();

        public ActionResult ReportePedido()
        {
            ReportViewer rp = new ReportViewer();
            rp.ProcessingMode = ProcessingMode.Local;
            rp.SizeToReportContent = true;

            SqlConnection cn = new SqlConnection("server=SUITEC102-ST11;database=Negocios2018;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from tb_pedidos", cn);

            dsNegocios ds = new dsNegocios();
            da.Fill(ds,ds.tb_pedidos.TableName);

            rp.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\Report1.rdlc";
            rp.LocalReport.DataSources.Add(new ReportDataSource("dsReporte", ds.Tables[0]));

            ViewBag.ReportViewer = rp;
            return View();

        }


        public ActionResult Index_()
        {
            return View(ped.ListaPedidos());
        }



        public ActionResult AgregarPedido()
        {
            ViewBag.empleados = new SelectList(emp.ListaEmpleados(), "idempleado", "nomempleado");
            return View(new Pedido());
        }

        [HttpPost]
        public ActionResult AgregarPedido(Pedido reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            ViewBag.mensaje = ped.AgregarPedido(reg);
            ViewBag.empleados = new SelectList(emp.ListaEmpleados(), "idempleado", "nomempleado", reg.idempleado);
            return View(reg);
        }

       
    }
}