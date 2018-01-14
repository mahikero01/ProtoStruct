using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PW01.Models;
using PW01.Services;

namespace PW01.Controllers
{
    [Produces("application/json")]
    [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        // GET: api/Cities
        [HttpGet()]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();
            var results = new List<CityWithoutPointsOfInterestDTO>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(
                        new CityWithoutPointsOfInterestDTO
                        {
                            Id = cityEntity.iD,
                            Description = cityEntity.Description,
                            Name = cityEntity.Name
                        });
            };
            //var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDTO>>(cityEntities);

            return Ok(results);
        }
        

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            { 
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityResult = new CityDTO()
                {
                    Id = city.iD,
                    Description = city.Description,
                    Name = city.Name
                };

                foreach (var poi in  city.PointsOfInterest)
                {
                    cityResult.PointsOfInterest.Add(
                            new PointOfInterestDTO()
                            {
                                Id = poi.Id,
                                Name = poi.Name,
                                Description = poi.Deescription
                            });
                }

                return Ok(cityResult);

            }

            var cityWithoutPointsOfInterestResult =
                    new CityWithoutPointsOfInterestDTO()
                    {
                        Id = city.iD,
                        Name = city.Name,
                        Description = city.Description
                    };

            return Ok(cityWithoutPointsOfInterestResult);
        }

        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
