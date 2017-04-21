using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BB.Presentation.DataContext.DBContext;
using BB.Presentation.Models.Pages;

namespace BB.Presentation.Controllers.CMS.Pages
{
    public class PageNodesController : ApiController
    {
        private DbInit db = new DbInit();

        // GET: api/PageNodes
        public IQueryable<PageNodes> GetPageNodes()
        {
            return db.PageNodes;
        }

        // GET: api/PageNodes/5
        [ResponseType(typeof(PageNodes))]
        public async Task<IHttpActionResult> GetPageNodes(int id)
        {
            PageNodes pageNodes = await db.PageNodes.FindAsync(id);
            if (pageNodes == null)
            {
                return NotFound();
            }

            return Ok(pageNodes);
        }

        // PUT: api/PageNodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPageNodes(int id, PageNodes pageNodes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pageNodes.Id)
            {
                return BadRequest();
            }

            db.Entry(pageNodes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageNodesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PageNodes
        [ResponseType(typeof(PageNodes))]
        public async Task<IHttpActionResult> PostPageNodes(PageNodes pageNodes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PageNodes.Add(pageNodes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pageNodes.Id }, pageNodes);
        }

        // DELETE: api/PageNodes/5
        [ResponseType(typeof(PageNodes))]
        public async Task<IHttpActionResult> DeletePageNodes(int id)
        {
            PageNodes pageNodes = await db.PageNodes.FindAsync(id);
            if (pageNodes == null)
            {
                return NotFound();
            }

            db.PageNodes.Remove(pageNodes);
            await db.SaveChangesAsync();

            return Ok(pageNodes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PageNodesExists(int id)
        {
            return db.PageNodes.Count(e => e.Id == id) > 0;
        }


        [Route("api/PageRecursiveNodes/")]
        [ResponseType(typeof(PageNodes))]
        public IHttpActionResult Get()
        {
            List<PageNodes> locations;
            List<Models.Pages.Pages> records;

            using (DbInit context = new DbInit())
            {
                locations = context.PageNodes.ToList();
                records = locations.Where(l => l.ParentId == null).OrderBy(l => l.Order)
                    .Select(l => new Models.Pages.Pages
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Order = l.Order,
                        Children = GetChildren(locations, l.Id)
                    }).ToList();
            }
            return Ok(records);
        }
        
        private List<Models.Pages.Pages> GetChildren(List<PageNodes> locations, int parentId)
        {
            return locations.Where(c => c.ParentId == parentId).OrderBy(c => c.Order)
                .Select(c => new Models.Pages.Pages
                {
                    Id = c.Id,
                    Name = c.Name,
                    Order = c.Order,
                    Children = GetChildren(locations, c.Id)
                }).ToList();
        }
    }
}