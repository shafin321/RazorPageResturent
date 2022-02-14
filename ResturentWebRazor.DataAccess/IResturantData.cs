using ResturentWebRazor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResturentWebRazor.DataAccess
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GettAllResturantByName(string name);
        Resturant GetById(int id);
        Resturant Update(Resturant updateResturant);
        Resturant Create(Resturant resturant);
        int Commit();
        

        
    }

    public class InMemoryResturantData : IResturantData
    {
        public List<Resturant> resurants;
        public InMemoryResturantData()
        {
            // resurants = new List<Resturant>();
            //resurants.Add(new Resturant { Id = 1, Name = "Chiken Pizza", Cuisine = CuisineType.Italian, Location = "Chalmers" });
            // creating a  new Resturent to the list 
            resurants = new List<Resturant>()
            {
                new Resturant{Id=1, Name="Dominus Pizza", Cuisine=CuisineType.Italian, Location="Chalmers"},
                new Resturant{Id=2, Name="Spice Cusine" , Cuisine=CuisineType.Mexican, Location="Valand"},
                new Resturant{Id=3, Name="Tarka" , Cuisine=CuisineType.Indain, Location="mondal"}

             };


        }

        public int Commit()
        {
            
            return 0;
        }

        public Resturant Create(Resturant resturant)
        {
           resurants.Add(resturant);
         //  resturant.Id = resurants.Max(r => r.Id) + 1;
            return resturant;
        }

        public Resturant GetById(int id)
        {
            return resurants.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Resturant> GettAllResturantByName(string name=null)
        {

            return from r in resurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) // r.Name==name  
                   orderby r.Name
                   select r;
            

        }

        public Resturant Update(Resturant updateResturant)
        {
            var resturant = resurants.FirstOrDefault(r => r.Id == updateResturant.Id);

            if(resturant != null)
            {
                //compy information from updated resturant from existing resturant 
                resturant.Name = updateResturant.Name; //Copy to the resturent.Name from updateResturant.Name;
                resturant.Location = updateResturant.Location;
                resturant.Cuisine = updateResturant.Cuisine;
                                                   
            }

            return resturant;
        }

        


    }
}
