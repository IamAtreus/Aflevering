using Microsoft.AspNetCore.Mvc;
using Vicevært.Application.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Api.Controllers
{

        [Route("/api/Lejer")]
        [ApiController]
        public class LejerController : ControllerBase
        {

            private readonly ILejerQuery _lejerQuery;

            public LejerController(ILejerQuery lejerQuery)
            {

                _lejerQuery = lejerQuery;
            }


            [HttpGet]
            public async Task<ActionResult<IEnumerable<LejerDto>>> GetAsync()
            {
                var result = new List<LejerDto>();
                var lejer = await _lejerQuery.GetLejerAsync();
                lejer.ToList()
                    .ForEach(a => result.Add(new LejerDto
                    {
                        LejerId = a.LejerId,
                        LejemaalId = a.LejemaalId,
                        FirstName = a.FirstName,
                        MiddleName = a.MiddleName,
                        LastName = a.LastName,
                        Email = a.Email,
                        PhoneNumber = a.PhoneNumber,
                    }));
                return result;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<LejerDto?>> GetAsync(int id)
            {
                var lejer = await _lejerQuery.GetLejerAsync(id);
                if (lejer is null) return BadRequest();
                return new LejerDto
                {
                    LejerId = lejer.LejerId,
                    LejemaalId = lejer.LejemaalId,
                    FirstName = lejer.FirstName,
                    MiddleName = lejer.MiddleName,
                    LastName = lejer.LastName,
                    Email = lejer.Email,
                    PhoneNumber = lejer.PhoneNumber,
                };
            }

 
        }
 }

