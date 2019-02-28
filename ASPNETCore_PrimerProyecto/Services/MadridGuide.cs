using MadridGuide.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadridGuide.Services
{
    public interface IMadridGuide
    {
        IList<PlaceOfInterest> GetPlacesOfInterest();
        void AddPlaceOfInterest(PlaceOfInterest place);
    }
    public class MadridGuideClass : IMadridGuide
    {
        private static List<PlaceOfInterest> placesOfInterest = new List<PlaceOfInterest>() { 
            PlaceOfInterest.Create("La Gran Vía", Address.Create("C:/ GranVia")),
            PlaceOfInterest.Create("Puerta de Alcalá", Address.Create("Plaza de la independencia")),
            PlaceOfInterest.Create("Estadio Vicente Calderón", Address.Create("Paseo Melancolicos, 7")),
            PlaceOfInterest.Create("Chicote ", Address.Create("C:/ GranVia, 15")),
            PlaceOfInterest.Create("Las 4 torres", Address.Create("Paseo de la Castellana, s/n")),
            PlaceOfInterest.Create("Agencia EFE", Address.Create("Av. de Burgos, 8B")),
            PlaceOfInterest.Create("Plaza Mayor", Address.Create("Plaza Mayor, 1")),
            PlaceOfInterest.Create("Museo Nacional del Prado", Address.Create("Paseo del Prado, s/n"))
       };

        public IList<PlaceOfInterest> GetPlacesOfInterest()
        {
            return placesOfInterest.ToList();
        }

        public void AddPlaceOfInterest(PlaceOfInterest place)
        {
            placesOfInterest.Add(place);
        }
    }
}
