using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TocaLivrosTeste.Dados;
using TocaLivrosTeste.Entidades;
using TocaLivrosTeste.MVC.ViewModels;

namespace TocaLivrosTeste.MVC.Controllers
{
    public class PedidosController : Controller
    {
        private TesteTocaLivrosContext db = new TesteTocaLivrosContext();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidoViewModel = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(db.Pedidos.ToList());
            return View(pedidoViewModel);
        }

        public PartialViewResult PedidosPorCliente(int? id)
        {
            var pedidoViewModel = Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(db.Pedidos.ToList());
            var pedidoCliente = pedidoViewModel.Where(p => p.ClienteId == id).ToList();
            if (pedidoCliente.Count > 0)
            {
                return PartialView("_PedidosPorCliente", pedidoCliente);
            }
            else
            {
                return null;
            }
        }


        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,DataCadastro,Descricao,Situacao,ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,DataCadastro,Descricao, Situacao,ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            var pedidoViewModel = Mapper.Map<Pedido, PedidoViewModel>(pedido);
            return View(pedidoViewModel);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
