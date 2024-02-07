using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIAssignment.Models;

namespace WebApIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static List<Movie> list = new List<Movie>()
        {
            new Movie{Id=1,MName="Salaar",StatCast="Prabhas",Director="Neel",Producer="Dil Raju",ReleaseDate=new DateTime(day:30,month:12,year:2023)},
             new Movie{Id=2,MName="Salaar",StatCast="Prabhas",Director="Neel",Producer="Dil Raju",ReleaseDate=new DateTime(day:30,month:12,year:2023)}
        };
        [HttpGet(Name = "GetMovie")]
        public IEnumerable<Movie> Get()
        {
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            Movie mvi = list.SingleOrDefault(x => x.Id == id);
            if (mvi == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(mvi);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Movie> Delete(int id)
        {
            Movie mvi = list.SingleOrDefault(x => x.Id == id);
            if (mvi == null)
            {
                return NotFound();

            }
            else
            {
                list.Remove(mvi);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Movie> Post(Movie newmovie)
        {
            list.Add(newmovie);
            return CreatedAtAction(nameof(Get),  newmovie);
        }
        [HttpPut("{id}")]
        public ActionResult<Movie> Put(int id,Movie updMvi)
        {
            Movie extmvi = list.SingleOrDefault(x => x.Id == id);
            if (extmvi == null)
            {
                return NotFound();

            }
            else
            {
                extmvi.MName = updMvi.MName;
                extmvi.StatCast = updMvi.StatCast;
                extmvi.Director = updMvi.Director;
                extmvi.Producer = updMvi.Producer;  
                extmvi.ReleaseDate = updMvi.ReleaseDate;
                return NoContent();
            }
        }
    }
}
