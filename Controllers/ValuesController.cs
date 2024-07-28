using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace to_do_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<items> item = new List<items>();
        private static int id = 1;
        [HttpGet("getbyid")]
        public IActionResult getitembyid(int id)
        {
            var e = item.SingleOrDefault(x => x.Id == id);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }
        [HttpPost("creatnewitem")]
        public IActionResult creattitem(items new_item)
        {
            new_item.Id = id++; ;
            item.Add(new_item);
            return CreatedAtAction(nameof(getitembyid), new { iid = new_item.Id }, new_item);
        }


        [HttpPatch("{status}")]
        public IActionResult statuspdate(bool status, items iitem)
        {

            var e = item.SingleOrDefault(x => x.Id == iitem.Id);
            if (e == null) { return NotFound(); }
            e.status = status;
            return Ok(e);
        }
        [HttpPut]
        public IActionResult updateitems(items itemsss)

        {
            var e = item.SingleOrDefault(x => x.Id == itemsss.Id);
            if (e == null) { return NotFound(); }
            e.Task_desc = itemsss.Task_desc;
            e.priority = itemsss.priority;
            e.status = itemsss.status;
            return Ok(e);
        }
    
    [HttpDelete]
    public IActionResult deleteitem(int id) 
    {
        var e = item.SingleOrDefault(items => items.Id == id);
            if (e == null) { return NotFound(); };
            //if the item not done iw won't be deleted 
            if(e.status==false) {  return BadRequest(); }
            item.Remove(e);
            return NoContent();
    }
    }

}
