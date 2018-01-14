﻿using System;
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
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;

        public PointsOfInterestController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        // GET: api/cities/{id}/PointsOfInterest
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }

            var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterestForCity(cityId);
            var pointsOfInterestForCityResults = new List<PointOfInterestDTO>();

            foreach (var poi in pointsOfInterestForCity)
            {
                pointsOfInterestForCityResults.Add(
                        new PointOfInterestDTO()
                        {
                            Id = poi.Id,
                            Name = poi.Name,
                            Description = poi.Deescription
                        });
            }

            return Ok(pointsOfInterestForCityResults);
        }

        // GET: api/cities/{id}/PointsOfInterest/{id}
        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExist(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

 
        
        // POST: api/PointsOfInterest
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/PointsOfInterest/5
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