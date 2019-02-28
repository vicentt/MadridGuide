using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadridGuide.Services;
using Microsoft.AspNetCore.Mvc;

namespace MadridGuide.Api.Controllers
{
    public class MadridController : Controller
    {
        private readonly IMadridGuide madridGuide;

        public MadridController(IMadridGuide madridGuide)
        {
            this.madridGuide = madridGuide;
        }

        [HttpGet]
        [Route("places"), FormatFilter]
        public IActionResult Index() 
        {
            return Ok(madridGuide.GetPlacesOfInterest());
        }

        //[HttpGet]
        //[Route("places/search")]
        ////[ShortCircuitResourceFilter]
        //[RequiredHeader("Vicen")]
        //public IActionResult Search([RequiredFromQuery] string filter)
        //{
        //    return Ok(madridGuide.GetPlacesOfInterest()
        //             .Where(s => s.MatchesSearch(filter)));
        //}

        [HttpGet]
        [Route("places/searchvicen")]
        //[ShortCircuitResourceFilter]
        public IActionResult SearchVicen()
        {
            return Ok("Hola");
        }


        //[HttpPost]
        //[Route("places")]
        //public IActionResult Create([FromBody] CreatePlaceRequest createPlaceRequest)
        //{
        //    madridGuide.AddPlaceOfInterest(
        //        PlaceOfInterest.Create(createPlaceRequest.Name,
        //        Address.Create(createPlaceRequest.Address)));

        //    return Ok();
        //}
        //[HttpPost]
        //[Route("places/ask")]
        //public IActionResult Ask([ModelBinder(BinderType = typeof(HumanSearchBinder))] HumanSearchRequest humanSearchRequest)
        //{
        //    var targetPlace = madridGuide
        //                      .GetPlacesOfInterest()
        //                      .FirstOrDefault(s => s.Search(humanSearchRequest.Search));

        //    string moodMessage = humanSearchRequest.Mood == MoodStatus.Happy
        //        ? "Nos alegra que este contento, " :
        //        humanSearchRequest.Mood == MoodStatus.Unhappy ?
        //                                   "Vamos a intentar animarle,"
        //                                   : string.Empty;


        //    return Ok(
        //           $"{moodMessage} le recomendamos {targetPlace.Name} en {targetPlace.Address.AddressLine}"
        //        );

        //}
    }
}