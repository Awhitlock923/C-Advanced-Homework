using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class NumbersController : Controller
    {
        private readonly TodoContext _context;

        public NumbersController(TodoContext context)
        {
            _context = context;

            //if (_context.NumbersModel.Count() == 0)
            //{
            //    _context.NumbersModel.Add(new NumbersModel { sum = 0 });
            //    _context.SaveChanges();
            //}
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("double/{number}")]
        public int GetDouble(int number)
        {
            return number + number;
        }

        [HttpGet("CountUp/{number}")]
        public string GetCount(int number)
        {
            //List < int > count = new List<int>();
            int i = 1;
            string a = "";
            while (i < number + 1)
            {
                if (a == "")
                {
                    a += Convert.ToString(i);
                }
                else
                {
                    a += "," + Convert.ToString(i);
                }
                //count.Add(i);
                i++;
            }
            return a;
        }

        
        

        
        [HttpGet("runningsum/{number}")]
        public async Task<ActionResult<NumbersModel>> GetNumbersModel(int number)
        {
            var NumbersModel = _context.NumbersModel.FirstOrDefault();

            NumbersModel.sum = number + NumbersModel.sum;

            _context.SaveChanges();
            
            return NumbersModel;
        }

        [HttpGet("runningmultiple/{number}")]
        public async Task<ActionResult<NumbersModel>> GetNumbersModel1(int number)
        {
            var NumbersModel = _context.NumbersModel.FirstOrDefault();

            NumbersModel.sum = number * NumbersModel.sum;

            _context.SaveChanges();

            return NumbersModel;
        }

        [HttpGet("runningdivide/{number}")]
        public async Task<ActionResult<NumbersModel>> GetNumbersModel2(int number)
        {
            var NumbersModel = _context.NumbersModel.FirstOrDefault();

            NumbersModel.sum = number / NumbersModel.sum;

            _context.SaveChanges();

            return NumbersModel;
        }

        [HttpGet("fibonatchi/{number}")]
        public string GetNumbersModel3(int number)
        {
            int i = 0;
            long numb1 = 0;
            long numb2 = 1;
            long fib = 0;
            string sequence = "";
            number--;

            while (i < number)
            {
                
                numb1 = fib;
                sequence += Convert.ToString(fib);
                fib = numb1 + numb2;
                i++;
                if(i < number)
                {
                    sequence += ", ";
                    numb2 = fib;
                    sequence += Convert.ToString(fib);
                    sequence += ", ";
                    fib = numb1 + numb2;
                    i++;
                }
            }
            return sequence;

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<controller>
      

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
