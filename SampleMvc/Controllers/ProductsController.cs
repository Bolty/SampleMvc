using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataAccess;

namespace SampleMvc.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;

        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _repository.Get<Product>().Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.Get<Product>(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_repository.Get<Category>(), "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_repository.Get<Category>(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.Get<Product>(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_repository.Get<Category>(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_repository.Get<Category>(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.Get<Product>(id.Value) ;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _repository.Get<Product>(id);
            _repository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
