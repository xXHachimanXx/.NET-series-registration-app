using System;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie> {
        private List<Serie> seriesList = new List<Serie>();

        public void Update(int id, Serie obj)
		{
			seriesList[id] = obj;
		}

		public void Excludes(int id)
		{
			seriesList[id].Excludes();
		}

		public void Insert(Serie obj)
		{
			seriesList.Add(obj);
		}

		public List<Serie> List()
		{
			return seriesList;
		}

		public int NextId()
		{
			return seriesList.Count;
		}
        
		public Serie ReturnById(int id)
		{
			return seriesList[id];
		}

    }
}